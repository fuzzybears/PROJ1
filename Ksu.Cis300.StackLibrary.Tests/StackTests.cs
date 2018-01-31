/* StackTests.cs
 * Author: Rod Howell
 */
using NUnit.Framework;
using System;

namespace Ksu.Cis300.StackLibrary.Tests
{
    /// <summary>
    /// A unit tests class for the class library Ksu.Cis300.StackLibrary.
    /// </summary>
    [TestFixture]
    public class StackTests
    {
        /// <summary>
        /// Tests whether the array size is initially 5.
        /// </summary>
        [Test]
        public void TestAInitialCapacity()
        {
            Stack<double> s = new Stack<double>();
            Assert.That(s.Capacity, Is.EqualTo(5));
        }

        /// <summary>
        /// Tests that upon clearing a stack, its Count is 0 and its Capacity is 5.
        /// </summary>
        [Test]
        public void TestDClear()
        {
            Stack<string> s = new Stack<string>();
            s.Push("abc");
            s.Push("xyz");
            s.Clear();
            Assert.Multiple(() =>
            {
                Assert.That(s.Count, Is.EqualTo(0));
                Assert.That(s.Capacity, Is.EqualTo(5));
            });
        }

        /// <summary>
        /// Tests a Peek on an empty stack. The test will pass if an InvalidOperationException
        /// is thrown; otherwise, it will fail.
        /// </summary>
        [Test]
        public void TestAEmptyPeek()
        {
            Stack<string> s = new Stack<string>();
            try
            {
                s.Peek();
                Assert.Fail("No exception thrown.");
            }
            catch (InvalidOperationException)
            {
                Assert.Pass();
            }
            catch (Exception e)
            {
                Assert.Fail(e.GetType().ToString() + " thrown.");
            }
        }

        /// <summary>
        /// Tests a Pop on an empty stack. The test will pass if an InvalidOperationException
        /// is thrown. Otherwise, it will fail.
        /// </summary>
        [Test]
        public void TestAEmptyPop()
        {
            Stack<double> s = new Stack<double>();
            try
            {
                s.Pop();
                Assert.Fail("No exception thrown.");
            }
            catch (InvalidOperationException)
            {
                Assert.Pass();
            }
            catch (Exception e)
            {
                Assert.Fail(e.GetType().ToString() + " thrown.");
            }
        }

        /// <summary>
        /// Tests whether the count is correctly updated after pushing twice.
        /// The count should be 2.
        /// </summary>
        [Test]
        public void TestBCountAfterPush()
        {
            Stack<int> s = new Stack<int>();
            s.Push(1);
            s.Push(2);
            Assert.That(s.Count, Is.EqualTo(2));
        }

        /// <summary>
        /// Tests whether the count is correctly updated after pushing three times
        /// and popping once.
        /// </summary>
        [Test]
        public void TestCCountAfterPop()
        {
            Stack<char> s = new Stack<char>();
            s.Push('a');
            s.Push('b');
            s.Push('c');
            s.Pop();
            Assert.That(s.Count, Is.EqualTo(2));
        }

        /// <summary>
        /// Tests whether Peek returns the correct value after three items are pushed onto
        /// the stack.
        /// </summary>
        [Test]
        public void TestBSimplePeek()
        {
            Stack<int> s = new Stack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            Assert.That(s.Peek(), Is.EqualTo(3));
        }

        /// <summary>
        /// Tests whether Pop returns the correct value after three items are pushed onto
        /// the stack.
        /// </summary>
        [Test]
        public void TestCSimplePop()
        {
            Stack<char> s = new Stack<char>();
            s.Push('a');
            s.Push('b');
            s.Push('c');
            Assert.That(s.Pop(), Is.EqualTo('c'));
        }

        /// <summary>
        /// Tests a sequence of three Pushes followed by three Pops.
        /// </summary>
        [Test]
        public void TestEMultiplePop()
        {
            Stack<int> s = new Stack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            int first = s.Pop();
            int second = s.Pop();
            int third = s.Pop();
            Assert.Multiple(() =>
            {
                Assert.That(first, Is.EqualTo(3));
                Assert.That(second, Is.EqualTo(2));
                Assert.That(third, Is.EqualTo(1));
            });
        }

        /// <summary>
        /// Pushes k values onto s. The values are successive powers of 2.
        /// </summary>
        /// <param name="k">The number of values to push</param>
        /// <param name="s">The stack on which to push.</param>
        /// <returns>The sum of the elements pushed.</returns>
        private int PushMultiple(int k, Stack<int> s)
        {
            int val = 1;
            int sum = 0;
            for (int i = 0; i < k; i++)
            {
                sum += val;
                s.Push(val);
                val *= 2;
            }
            return sum;
        }

        /// <summary>
        /// Tests whether the capacity is still 5 after 5 Pushes.
        /// </summary>
        [Test]
        public void TestFFiveCapacity()
        {
            Stack<int> s = new Stack<int>();
            PushMultiple(5, s);
            Assert.That(s.Capacity, Is.EqualTo(5));
        }

        /// <summary>
        /// Tests whether the capacity is 10 after 6 Pushes.
        /// </summary>
        [Test]
        public void TestGExpandCapacity()
        {
            Stack<int> s = new Stack<int>();
            PushMultiple(6, s);
            Assert.That(s.Capacity, Is.EqualTo(10));
        }

        /// <summary>
        /// Tests whether the capacity is 20 after 11 Pushes.
        /// </summary>
        [Test]
        public void TestHDoubleExpandCapacity()
        {
            Stack<int> s = new Stack<int>();
            PushMultiple(11, s);
            Assert.That(s.Capacity, Is.EqualTo(20));
        }

        /// <summary>
        /// Removes all elements from the stack, computing their sum.
        /// </summary>
        /// <param name="s">The stack.</param>
        /// <returns>The sum of the elements removed from the stack.</returns>
        private int SumAll(Stack<int> s)
        {
            int sum = 0;
            while (s.Count > 0)
            {
                sum += s.Pop();
            }
            return sum;
        }

        /// <summary>
        /// Tests whether a single expansion preserves all elements. The test is done
        /// by summing the elements as the are popped from the stack, and comparing
        /// with the sum of the elements pushed onto the stack.
        /// </summary>
        [Test]
        public void TestGExpand()
        {
            Stack<int> s = new Stack<int>();
            int inSum = PushMultiple(6, s);
            int outSum = SumAll(s);
            Assert.That(outSum, Is.EqualTo(inSum));
        }

        /// <summary>
        /// Tests whether two expansions preserve all elements.  The test is done by
        /// summing the elements as they are popped from the stack, and comparing
        /// with the sum of the elements pushed onto the stack.
        /// </summary>
        [Test]
        public void TestHDoubleExpand()
        {
            Stack<int> s = new Stack<int>();
            int inSum = PushMultiple(11, s);
            int outSum = SumAll(s);
            Assert.That(outSum, Is.EqualTo(inSum));
        }
    }
}