// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.IO.Tests
{
    internal class UnseekableFileStream : FileStream
    {
        public UnseekableFileStream(string path, FileMode mode)
            : base(path, mode)
        { }

        public override bool CanSeek
        {
            get
            {
                return false;
            }
        }
    }
}
