using System;
using Windows.Phone.Speech.Synthesis;
using SDN.Rss.Interfaces;
using SDN.Rss.WinPhone.PlatformSpecifics;

[assembly: Xamarin.Forms.Dependency(typeof(WinPhoneTextToSpeech))]

namespace SDN.Rss.WinPhone.PlatformSpecifics
{
    public class WinPhoneTextToSpeech : ITextToSpeech
    {
        public async void Speak(string text)
        {
            var synthesizer = new SpeechSynthesizer();
            await synthesizer.SpeakTextAsync(text);
        }
    }
}