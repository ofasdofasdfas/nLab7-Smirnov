using System;
using System.Collections.Generic;
using System.Windows;

namespace StackExample
{
    public partial class MainWindow : Window
    {
        private Stack<int> stack;

        public MainWindow()
        {
            InitializeComponent();
            stack = new Stack<int>();
        }

        private void OnEnterNumbersClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int N = int.Parse(txtN.Text);
                if (N <= 0)
                {
                    MessageBox.Show("Число N должно быть больше 0");
                    return;
                }

                List<int> numbers = new List<int>();
                for (int i = 0; i < N; i++)
                {
                    string input = Microsoft.VisualBasic.Interaction.InputBox($"Введите число {i + 1}", "Ввод числа");
                    int num;
                    if (int.TryParse(input, out num))
                    {
                        numbers.Add(num);
                    }
                    else
                    {
                        MessageBox.Show($"Неверный формат числа '{input}'. Повторите ввод.");
                        i--; // Decrement i to repeat input for the same number
                    }
                }

                // Clear previous stack and refill with new numbers
                stack.Clear();
                foreach (int num in numbers)
                {
                    stack.Push(num);
                }

                // Display the top element of the stack
                int topElement = stack.Peek();
                txtResult.Text = $"Вершина стека (последний введенный элемент): {topElement}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат числа N. Введите целое положительное число.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
