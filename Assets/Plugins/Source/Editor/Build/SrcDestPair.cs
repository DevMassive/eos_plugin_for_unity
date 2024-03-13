/*
 * Copyright (c) 2024 PlayEveryWare
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using UnityEngine;
using System;

namespace PlayEveryWare.EpicOnlineServices.Editor.Build
{
    [Serializable]
    public class SrcDestPair
    {
        // Allows for adding a comment
        [SerializeField] 
        public string comment;

        [SerializeField] 
        public string src;

        [SerializeField] 
        public string dest;

        // if this field is present, the build will error out if the SHA of the src file
        // doesn't match this. This allows as a reminder to update files
        [SerializeField] 
        public string sha1;

        // Files matching this pattern will 
        [SerializeField] 
        public string ignore_regex;

        public bool IsCommentOnly()
        {
            return (string.IsNullOrEmpty(src) &&
                    string.IsNullOrEmpty(dest) &&
                    string.IsNullOrEmpty(ignore_regex)) || (null != comment && comment.StartsWith("//"));
        }
    }
}