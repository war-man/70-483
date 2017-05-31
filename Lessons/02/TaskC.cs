﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lessons._02
{
    /// <summary>
    /// Simulate parallel processing by using Parallel.ForEach() over a thread-unsafe collection. 
    /// The processing has to fail with an exception related to parallel access. 
    /// Provide a solution with concurrent collection.
    /// </summary>
    public struct TaskC
    {
        private static readonly char[] _charArr = new char[] {'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð', 'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð', 'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð', 'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð', 'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð', 'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð' , 'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð', 'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð', 'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð', 'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð', 'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð', 'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð', 'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð', 'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð' , 'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð', 'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð', 'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð', 'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð', 'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð', 'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð', 'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð' };
        private static readonly ConcurrentBag<char> _charConcurrentBag = new ConcurrentBag<char>() {'a', '1', '>', 'c', 'd', '૱', '꠸', '┯', '┰', '┱', '┲', '❗', '►', '◄', 'Ă', 'ă', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ǖ', 'ǖ', 'Ꞁ', '¤', 'Ð' };

        public static void Run()
        {
            try
            {
                var chars = _charArr
                    .AsParallel()
                    .Where(c => UnsafeIsLetter(c));

                chars.ForAll(c => Console.WriteLine(c));

            }
            catch(AggregateException e)
            {
                Console.WriteLine( e.Message);
            }
        }

        private static bool UnsafeIsLetter(char character)
        {
            return Char.IsLetter(character);
        }

        private static bool SafeIsLetter(char character)
        {
            var safeCharacter = character;
            return Char.IsLetter(safeCharacter);
        }
    }
}