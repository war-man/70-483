﻿using System;
using System.Net;

namespace Lessons._05
{
    // Write thread-unsafe implementation of System.Lazy<T>.
    // Provide just public Lazy(Func<T> valueFactory) constructor.
    // Use the new class LazyThreadUnsafe<T> for googleContentLazy.
    public class TaskD
    {
        public static void Run()
        {
            var googleContentLazy = new LazyThreadUnsafe<string>(() =>
            {
                return new WebClient().DownloadString("http://www.google.com");
            });

            Console.WriteLine(googleContentLazy.Value);
        }

        public class LazyThreadUnsafe<T>
        {
            private Func<T> toEval;

            public LazyThreadUnsafe(Func<T> valueFactory)
            {
                toEval = valueFactory;
            }

            public T Value
            {
                get
                {
                    return toEval.Invoke();
                }
            }
        }
    }
}