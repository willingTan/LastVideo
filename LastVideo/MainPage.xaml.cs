﻿using LastVideo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace LastVideo
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public ObservableCollection<Contentlist> Items { get; set; }

        public bool IsPullRefresh
        {
            get
            {
                return _isPullRefresh;
            }

            set
            {
                _isPullRefresh = value;
                OnPropertyChanged(nameof(IsPullRefresh));
            }
        }

        bool _isPullRefresh = false;
        public event PropertyChangedEventHandler PropertyChanged;
        

        public void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void scrollViewer_Loaded(object sender, RoutedEventArgs e)
        {
        }
        //下拉刷新，我放弃了

        private async void scrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            var sv = sender as ScrollViewer;

            if (!e.IsIntermediate)
            {
                if (sv.VerticalOffset == 0.0)
                {
                    IsPullRefresh = true;
                    await Task.Delay(2000);
                    sv.ChangeView(null, 30, null);
                }
                IsPullRefresh = false;
            }
        }
        
        public ObservableCollection<Contentlist> Examples { get; set; }
        SystemMediaTransportControls systemControls;
        //MediaElement myplayer = new MediaElement();
        public MainPage()
        {
            this.InitializeComponent();
            var view = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            view.TitleBar.BackgroundColor = Colors.Black;
            view.TitleBar.ButtonBackgroundColor = Colors.Black;
            Examples = new ObservableCollection<Contentlist>();
            systemControls = SystemMediaTransportControls.GetForCurrentView();
            //systemControls.ButtonPressed += SystemControls_ButtonPressed;

        }

        //关联不上啊，我的transportcontrol GG了,只有用封装好的了
        //哇，好气啊0.0，功能做不完了

        //private void SystemControls_ButtonPressed(SystemMediaTransportControls sender, SystemMediaTransportControlsButtonPressedEventArgs args)
        //{
        //    //throw new NotImplementedException();
        //    switch (args.Button)
        //    {
        //        case SystemMediaTransportControlsButton.Play:
        //            PlayMedia();
        //            break;
        //        case SystemMediaTransportControlsButton.Pause:
        //            PauseMedia();
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //async void PlayMedia()
        //{
        //    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        //    {
        //        myplayer.Play();
        //    });
        //}

        //async void PauseMedia()
        //{
        //    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        //    {
        //        myplayer.Pause();
        //    });
        //}

        //private void myplayer_CurrentStateChanged(object sender, RoutedEventArgs e)
        //{
        //    switch (myplayer.CurrentState)
        //    {
        //        case MediaElementState.Playing:
        //            systemControls.PlaybackStatus = MediaPlaybackStatus.Playing;
        //            break;
        //        case MediaElementState.Paused:
        //            systemControls.PlaybackStatus = MediaPlaybackStatus.Paused;
        //            break;
        //        case MediaElementState.Stopped:
        //            systemControls.PlaybackStatus = MediaPlaybackStatus.Stopped;
        //            break;
        //        case MediaElementState.Closed:
        //            systemControls.PlaybackStatus = MediaPlaybackStatus.Closed;
        //            break;
        //        default:
        //            break;
        //    }

        //}


        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            mypro.IsActive = true;
            mypro.Visibility = Visibility.Visible;

            await Videoproporty.Content(Examples);
            
            mypro.IsActive = false;
            mypro.Visibility = Visibility.Collapsed;
        }

        //private void myplayer_MediaOpened(object sender, RoutedEventArgs e)
        //{
        //}
    }
}
