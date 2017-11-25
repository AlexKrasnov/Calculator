using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Calculator
{
    public partial class GamePage : PhoneApplicationPage
    {
        ContentManager contentManager;
        GameTimer timer;
        SpriteBatch spriteBatch;

        public GamePage()
        {
            InitializeComponent();

            // Получить диспетчер содержимого из приложения
            contentManager = (Application.Current as App).Content;

            // Создайте таймер для этой страницы
            timer = new GameTimer();
            timer.UpdateInterval = TimeSpan.FromTicks(333333);
            timer.Update += OnUpdate;
            timer.Draw += OnDraw;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // В графическом устройстве включите визуализацию XNA для режима совместного использования
            SharedGraphicsDeviceManager.Current.GraphicsDevice.SetSharingMode(true);

            // Создание нового SpriteBatch, который может использоваться для рисования текстур.
            spriteBatch = new SpriteBatch(SharedGraphicsDeviceManager.Current.GraphicsDevice);

            // TODO: загрузите сюда содержимое игры с помощью this.content

            // Запуск таймера
            timer.Start();

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // Остановка таймера
            timer.Stop();

            // В графическом устройстве выключите визуализацию XNA для режима совместного использования
            SharedGraphicsDeviceManager.Current.GraphicsDevice.SetSharingMode(false);

            base.OnNavigatedFrom(e);
        }

        /// <summary>
        /// Позволяет странице выполнять логику, такую как обновление окружения,
        /// поиск конфликтов, сбор входных данных и воспроизведение звука.
        /// </summary>
        private void OnUpdate(object sender, GameTimerEventArgs e)
        {
            // TODO: добавьте здесь логику обновления
        }

        /// <summary>
        /// Разрешает самостоятельную прорисовку страницы.
        /// </summary>
        private void OnDraw(object sender, GameTimerEventArgs e)
        {
            SharedGraphicsDeviceManager.Current.GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: добавьте здесь свой код прорисовки
        }
    }
}