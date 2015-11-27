using System;
using Android.OS;
using Android.Speech.Tts;
using SDN.Rss.Droid.PlatformSpecifics;
using SDN.Rss.Interfaces;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidTextToSpeech))]

namespace SDN.Rss.Droid.PlatformSpecifics
{
    public class AndroidTextToSpeech : Java.Lang.Object,
        ITextToSpeech, TextToSpeech.IOnInitListener
    {
        TextToSpeech _speaker;
        string _text;

        public void Speak(string text)
        {
            var ctx = Forms.Context;
            _text = text;

            if (_speaker == null)
                _speaker = new TextToSpeech(ctx, this);
            else   
                _speaker.Speak(_text, QueueMode.Flush, null,
                    DateTime.Now.Ticks.ToString());
        }

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                _speaker.Speak(_text, QueueMode.Flush, new Bundle(),
                    DateTime.Now.Ticks.ToString());
            }
        }
    }
}