using System;
using System.ComponentModel;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration
{
	[HelpURL("https://kb.heathenengineering.com/assets/steamworks/voice")]
	public class VoiceRecorder : MonoBehaviour
	{
		[Serializable]
		public class ByteArrayEvent : UnityEvent<byte[]>
		{
		}

		[Range(0f, 1f)]
		public float bufferLength = 0.25f;

		[ReadOnly(true)]
		[SerializeField]
		private bool isRecording;

		public UnityEvent evtStopedOnChatRestricted;

		public ByteArrayEvent evtVoiceStream;

		private float packetCounter;

		public bool IsRecording
		{
			get
			{
				return isRecording;
			}
			set
			{
				if (value != IsRecording)
				{
					if (value)
					{
						StartRecording();
					}
					else
					{
						StopRecording();
					}
				}
			}
		}

		private void Start()
		{
			packetCounter = bufferLength;
		}

		private void Update()
		{
			packetCounter -= Time.unscaledDeltaTime;
			if (!(packetCounter <= 0f))
			{
				return;
			}
			packetCounter = bufferLength;
			if (!isRecording)
			{
				return;
			}
			uint pcbCompressed;
			switch (SteamUser.GetAvailableVoice(out pcbCompressed))
			{
			case EVoiceResult.k_EVoiceResultOK:
			{
				byte[] array = new byte[pcbCompressed];
				SteamUser.GetVoice(bWantCompressed: true, array, pcbCompressed, out var nBytesWritten);
				if (nBytesWritten != 0)
				{
					evtVoiceStream.Invoke(array);
				}
				break;
			}
			case EVoiceResult.k_EVoiceResultNotInitialized:
				Debug.LogError("The Steamworks Voice system is not initialized and will be stopped.");
				SteamUser.StopVoiceRecording();
				break;
			case EVoiceResult.k_EVoiceResultNotRecording:
				SteamUser.StartVoiceRecording();
				break;
			case EVoiceResult.k_EVoiceResultRestricted:
				evtStopedOnChatRestricted.Invoke();
				SteamUser.StopVoiceRecording();
				break;
			case EVoiceResult.k_EVoiceResultNoData:
			case EVoiceResult.k_EVoiceResultBufferTooSmall:
			case EVoiceResult.k_EVoiceResultDataCorrupted:
				break;
			}
		}

		public void StartRecording()
		{
			isRecording = true;
			Voice.Client.StartRecording();
		}

		public void StopRecording()
		{
			isRecording = false;
			Voice.Client.StopRecording();
		}
	}
}
