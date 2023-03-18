using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections;

namespace Wintellect.PowerCollections.Tests
{
    [TestClass]
    public class Stack_Tests
    {
        [TestMethod]
        public void сount_should_be_zero_when_stack_empty()
        {
            Stack<bool> testCount = new Stack<bool>(1);

            Assert.AreEqual(0, testCount.Count);//Count ожидается 0 т.к. стек пустой
        }
        [TestMethod]
        public void сount_should_be_greater_than_zero_when_stack_not_empty()
        {
            Stack<int> testCount = new Stack<int>(3);

            testCount.Push(3);
            testCount.Push(8);

            Assert.AreEqual(2, testCount.Count);//Count ожидается 2 т.к. в стек было запушено 2 элемента
        }
        [TestMethod]
        public void сapacity_should_be_equal_to_constructor_parameter()
        {
            Stack<char> testCapacity = new Stack<char>(3);

            Assert.AreEqual(3, testCapacity.Capacity);//Capacity ожидается 3 т.к. в конструктор было передано значение 3 (размер стека равен 3) 
        }
        [TestMethod]
        public void isEmpty_should_be_true_when_stack_is_empty()
        {
            Stack<bool> testISEmpty = new Stack<bool>(2);

            Assert.IsTrue(testISEmpty.IsEmpty());//Ожидается true т.к. стек пустой
        }
        [TestMethod]
        public void isEmpty_should_be_false_when_stack_is_filled()
        {
            Stack<int> testISEmpty = new Stack<int>(3);

            testISEmpty.Push(1);
            testISEmpty.Push(2);

            Assert.IsFalse(testISEmpty.IsEmpty());//Ожидается false т.к. стек заполнен элементами
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void constructor_should_throw_exception_when_parameter_is_less_than_zero()
        {
            Stack<int> testConstructor = new Stack<int>(-1);// При передаче отрицательного значения в конструктор ожидается ошибка
        }

        [TestMethod]
        public void push_should_change_count_and_add_element_on_top_of_stack()
        {
            Stack<bool> testPush = new Stack<bool>(4);

            testPush.Push(true);
            testPush.Push(true);
            testPush.Push(false);

            Assert.AreEqual(3, testPush.Count);//Ожидается Count равный 3 т.к. запушено 3 элемента
            Assert.AreEqual(false, testPush.Top());//Ожидается false т.к. он был запушен последним
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void push_should_thow_exception_when_stack_overflow()
        {
            Stack<int> testPush = new Stack<int>(1);

            testPush.Push(1);
            testPush.Push(2);//При переполнении стека ожидается ошибка
        }

        [TestMethod]
        public void top_should_return_element_from_top_of_stack_and_not_change_count()
        {
            Stack<int> testTop = new Stack<int>(3);

            testTop.Push(5);
            testTop.Push(9);

            Assert.AreEqual(9, testTop.Top());//Ожидается 9 т.к. оно было запушено последним 
            Assert.AreEqual(2, testTop.Count);//Ожидается 2 т.к. Top не должен влиять на Count (извлекать значение из стека)
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void top_should_thow_exception_when_stack_is_empty()
        {
            Stack<int> testTop = new Stack<int>(2);

            testTop.Top();//Ожидается ошибка т.к. мы пытаемся получить значение из путсого стека
        }
        public void pop_should_return_element_from_top_of_stack_and_change_count()
        {
            Stack<int> testPop = new Stack<int>(3);

            testPop.Push(5);
            testPop.Push(9);

            Assert.AreEqual(9, testPop.Pop());//Ожидается 9 т.к. оно было запушено последним 
            Assert.AreEqual(5, testPop.Pop());//Ожидается 5 т.к. предыдущее значение(9) было извлечено и 5 стало последним элементом
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void pop_should_thow_exception_when_stack_is_empty()
        {
            Stack<int> testPop = new Stack<int>(3);
            testPop.Pop();//Ожидается ошибка т.к. мы пытаемся получить значение из путсого стека
        }

        [TestMethod]
        public void getEnumerator_should_return_reversed_array()
        {
            Stack<char> testEnumerator = new Stack<char>(10);
            char[] elements = new char[] { 'a', 'c', 'g' };

            foreach (char e in elements)
            {
                testEnumerator.Push(e);
            }

            var enumeratorArray = from e in testEnumerator select e;
            enumeratorArray = enumeratorArray.Reverse();

            CollectionAssert.AreEqual(elements, enumeratorArray.ToArray());
        }
    }
}