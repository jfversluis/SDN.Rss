using AVFoundation;
using SDN.Rss.iOS.PlatformSpecifics;
using SDN.Rss.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(iOSTextToSpeech))]

namespace SDN.Rss.iOS.PlatformSpecifics
{
    public class iOSTextToSpeech : ITextToSpeech
    {
        public void Speak(string text)
        {
            var synthesizer = new AVSpeechSynthesizer();

            var utterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate/6,
                Voice = AVSpeechSynthesisVoice.FromLanguage("nl-NL"),
                Volume = 0.5f,
                PitchMultiplier = 1.0f
            };

            synthesizer.SpeakUtterance(utterance);
        }
    }
}