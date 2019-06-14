using System;
using System.IO.Ports;
using System.Windows;
using Solid.Arduino;
using Solid.Arduino.Firmata;

namespace SerialCommunicator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialPort port = new SerialPort("COM3", 9600);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SliderChanger_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            try
            {
                port.Open();
                if (port.IsOpen && SliderLabel != null)
                {
                    port.Write(SliderChanger.Value.ToString());
                    SliderLabel.Content = "Value: " + SliderChanger.Value;
                }

                port.Close();
            }
            catch (Exception)
            {
                LoggerList?.Items.Add("Fail to open port (COM3)");
            }
        }
    }
}
