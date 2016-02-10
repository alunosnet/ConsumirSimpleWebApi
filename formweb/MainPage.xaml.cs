using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Net.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace formweb
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            using(var cliente=new HttpClient())
            {
                var valores = new Dictionary<string, string>
                {
                    { "p1",tbAEnviar.Text}
                   // { "p2","mundo" }
                };
                var conteudo = new FormUrlEncodedContent(valores);
                var resposta = await cliente.PostAsync("http://localhost:59237/inventario.aspx", conteudo);

                var str_resposta = await resposta.Content.ReadAsStringAsync();
                tbResposta.Text = str_resposta;
            };
        }
    }
}
