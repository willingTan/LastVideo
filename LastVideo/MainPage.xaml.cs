using LastVideo.Models;
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
using Windows.UI.ViewManagement;
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
    public sealed partial class MainPage : Page,INotifyPropertyChanged
    {
        //public ObservableCollection<Contentlist> Items { get; set; }

        //public bool IsPullRefresh
        //{
        //    get
        //    {
        //        return _isPullRefresh;
        //    }

        //    set
        //    {
        //        _isPullRefresh = value;
        //        OnPropertyChanged(nameof(IsPullRefresh));
        //    }
        //}

        //bool _isPullRefresh = false;
        //public event PropertyChangedEventHandler PropertyChanged;


        //public void OnPropertyChanged(string name)
        //{
        //    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //}

        //private void scrollViewer_Loaded(object sender, RoutedEventArgs e)
        //{
        //}
        ////下拉刷新，我放弃了

        //private async void scrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        //{
        //    var sv = sender as ScrollViewer;

        //    if (!e.IsIntermediate)
        //    {
        //        if (sv.VerticalOffset == 0.0)
        //        {
        //            IsPullRefresh = true;
        //            await Task.Delay(2000);
        //            sv.ChangeView(null, 30, null);
        //        }
        //        IsPullRefresh = false;
        //    }
        //}

        public string myuri { get; set; }
        public string time { get; set; }
        public ObservableCollection<Contentlist> Examples { get; set; }
        public ObservableCollection<Contentlist> Examples2 { get; set; }
        //SystemMediaTransportControls systemControls;
        //MediaElement myplayer = new MediaElement();
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

        public MainPage()
        {
            this.InitializeComponent();
            var view = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            view.TitleBar.BackgroundColor = Colors.Black;
            view.TitleBar.ButtonBackgroundColor = Colors.Black;
            Examples = new ObservableCollection<Contentlist>();
            Examples2 = new ObservableCollection<Contentlist>();
            ApplicationView.PreferredLaunchViewSize = new Size(1000, 600);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
			//    systemControls = SystemMediaTransportControls.GetForCurrentView();
			//    systemControls.ButtonPressed += SystemControls_ButtonPressed;
			//for(int i=0;i<20;i++)
			//{
			//    Examples.Add(Examples[i]);
			//}
		}

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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

        //private string ItemToKeyHandler(object item)
        //{
        //    Item dataItem = item as Item;
        //    if (dataItem == null) return null;

        //    return dataItem.Id.ToString();
        //}

        //public static string GetRelativeScrollPosition(ListViewBase listViewBase, ListViewItemToKeyHandler itemToKeyHandler)
        //{

        //} //怎么感觉所有方法都不行0.0,一定用了假的控件

        private async void Page_Loaded(object sender, RoutedEventArgs e)
		{
			mypro1.IsActive = true;
			mypro1.Visibility = Visibility.Visible;
			jiazai.Visibility = Visibility.Visible;
			await Task.Delay(1000);
            try
                {
				await Videoproporty.Content(Examples);
				jiazai.Visibility = Visibility.Collapsed;
				mypro1.IsActive = false;
				mypro1.Visibility = Visibility.Collapsed;
				mypro.IsActive = true;
				mypro.Visibility = Visibility.Visible;
				await Task.Delay(500);
				scrollviewer.ChangeView(null, 30, null);
				if (Examples.Count == 0) displayNoWifiDialog();
                }
            catch
            {
                //先不急
            }
			delay.Visibility = Visibility.Collapsed;
            mypro.IsActive = false;
            mypro.Visibility = Visibility.Collapsed;
        }
        private void MyVideo_ItemClick(object sender, ItemClickEventArgs e)
        {
            //GetSelectedItemFromListView(MyVideo);
            //无法获取点击item的值
            //if(a!=null)
            //{
            //    string uri;
            //    uri = a.ToString();
            //}
            try
            {
                Contentlist a = MyVideo.SelectedItem as Contentlist;
                myuri = a.video_uri;
                myplayer.Source = new Uri(myuri);
                myplayer.Visibility = Visibility.Visible;

                //不急
            }
            catch
            {
                //先不急
            }
        }

        //private object GetSelectedItemFromListView(ListView listView)
        //{
        //    return listView.SelectedItems[0];
        //}
        //
        private static async void displayNoWifiDialog()
        {
            ContentDialog noWifiDialog = new ContentDialog()
            {
                Title = "网络异常",
                Content = "请检查网络是否连接",
                PrimaryButtonText = "确定"
            };
            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }
        private void gettime()//获取时长还是没有成功
        {
            //time=MediaElement.NaturalDuration.HasTimeSpan;
        }

		//并没有发现这个有什么作用。。
        //private void scrollviewer_Loaded(object sender, RoutedEventArgs e)
        //{
        //    scrollviewer.ChangeView(null, 30, null);
        //}

        private async void scrollviewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            var sv = sender as ScrollViewer;
            if(!e.IsIntermediate)
            {
                if(sv.VerticalOffset==0.0)
                {
                    IsPullRefresh = true;
                    try
                    {
                        await Videoproporty.Content(Examples2);
                        if (Examples2.Count == 0) displayNoWifiDialog();
                    }
                    catch
                    {
                        //先不急
                    }
                    await Task.Delay(2000);
                    for (int i=0;i<5;i++)
                    {
                            if (Examples[0].create_time != Examples2[i].create_time) Examples.Insert(0, Examples2[i]);
                            else break;
                    }
                    sv.ChangeView(null, 30, null);
                }
                IsPullRefresh = false;
            }
        }
        //private void myplayer_MediaOpened(object sender, RoutedEventArgs e)
        //{
        //}

        //private void SystemControls_ButtonPressed(SystemMediaTransportControls sender, SystemMediaTransportControlsButtonPressedEventArgs args)
        //{
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

    }
}
