using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WCFDemo.Contracts;
using Binding = System.ServiceModel.Channels.Binding;

namespace WCFDemo.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void httpButton_Click(object sender, RoutedEventArgs e)
        {
            var demo = GetDemoService(new BasicHttpBinding(), "http://localhost/WCFDemo/Demo.svc");
            DateTime utcDate = demo.GetUtcDate();
            int count = demo.GetTotalNumberOfRequests();
            SetDateLabel(utcDate, count);
        }

        private void netTcpButton_Click(object sender, RoutedEventArgs e)
        {
            var demoService = GetDemoService(new NetTcpBinding(), "net.tcp://localhost/WCFDemo/Demo.svc");
            DateTime utcDate = demoService.GetUtcDate();
            int count = demoService.GetTotalNumberOfRequests();

            SetDateLabel(utcDate, count);
        }

        private void SetDateLabel(DateTime utcDate, int count)
        {
            dtLabel.Content = utcDate.ToString() + ", antal requests: " + count;
        }

        private static IDemo GetDemoService(Binding binding, string endpointAddress)
        {
            return ChannelFactory<IDemo>.CreateChannel(binding, new EndpointAddress(endpointAddress));
        }
    }
}
