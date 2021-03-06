// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Xunit;

namespace System.Runtime.InteropServices.Tests
{
    public class ReAllocCoTaskMemTests
    {
        [Fact]
        public void ReAllocCoTaskMem_Invoke_DataCopied()
        {
            const int Size = 3;
            IntPtr p1 = Marshal.AllocCoTaskMem(Size);
            IntPtr p2 = p1;
            try
            {
                for (int i = 0; i < Size; i++)
                {
                    Marshal.WriteByte(p1 + i, (byte)i);
                }

                int add = 1;
                do
                {
                    p2 = Marshal.ReAllocCoTaskMem(p2, Size + add);
                    for (int i = 0; i < Size; i++)
                    {
                        Assert.Equal((byte)i, Marshal.ReadByte(p2 + i));
                    }

                    add++;
                }
                while (p2 == p1); // stop once we've validated moved case
            }
            finally
            {
                Marshal.FreeCoTaskMem(p2);
            }
        }
    }
}
