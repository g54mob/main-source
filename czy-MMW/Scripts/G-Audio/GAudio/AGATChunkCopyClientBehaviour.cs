using System;
using UnityEngine;

namespace GAudio
{
	public abstract class AGATChunkCopyClientBehaviour : MonoBehaviour, IGATAudioThreadStreamClient
	{
		public Component observedAudioStreamComp;

		public bool observeTrack;

		public int observedChannel;

		protected float[] _data;

		protected IGATAudioThreadStream _observedStream;

		private Component _cachedStreamComp;

		private volatile bool _dataIsUpdated;

		private volatile bool _receivedZeroData;

		private volatile bool _needsData;

		private bool _inZeroState;

		protected virtual void Start()
		{
			UpdateObservedStream();
		}

		protected abstract void HandleAudioDataUpdate();

		protected abstract void HandleNoMoreData();

		private void Awake()
		{
			_data = new float[GATInfo.AudioBufferSizePerChannel];
			_needsData = true;
			_inZeroState = true;
		}

		void IGATAudioThreadStreamClient.HandleAudioThreadStream(float[] data, int offset, bool emptyData, IGATAudioThreadStream stream)
		{
			if (!_needsData)
			{
				return;
			}
			if (!emptyData)
			{
				int nbOfChannels = stream.NbOfChannels;
				int bufferSizePerChannel = stream.BufferSizePerChannel;
				if (nbOfChannels == 1)
				{
					Array.Copy(data, offset, _data, 0, bufferSizePerChannel);
				}
				else
				{
					int num = 0;
					bufferSizePerChannel *= nbOfChannels;
					offset += observedChannel;
					while (offset < bufferSizePerChannel)
					{
						_data[num] = data[offset];
						offset += nbOfChannels;
						num++;
					}
				}
			}
			_receivedZeroData = emptyData;
			_needsData = false;
			_dataIsUpdated = true;
		}

		private void Update()
		{
			if (_dataIsUpdated)
			{
				if (!_receivedZeroData)
				{
					HandleAudioDataUpdate();
					_inZeroState = false;
				}
				else if (!_inZeroState)
				{
					HandleNoMoreData();
					_inZeroState = true;
				}
				_dataIsUpdated = false;
				_needsData = true;
			}
			if (observedAudioStreamComp != _cachedStreamComp)
			{
				UpdateObservedStream();
			}
		}

		private void UpdateObservedStream()
		{
			IGATAudioThreadStream iGATAudioThreadStream = null;
			if (observeTrack)
			{
				GATPlayer gATPlayer = observedAudioStreamComp as GATPlayer;
				if (gATPlayer == null)
				{
					Debug.LogWarning("Could not find Player to observe track " + observedAudioStreamComp.name);
					return;
				}
				iGATAudioThreadStream = ((IGATAudioThreadStreamOwner)gATPlayer.GetTrack(observedChannel)).GetAudioThreadStream(0);
			}
			else if (observedAudioStreamComp != null)
			{
				iGATAudioThreadStream = observedAudioStreamComp as IGATAudioThreadStream;
				if (iGATAudioThreadStream == null)
				{
					if (observedAudioStreamComp is IGATAudioThreadStreamOwner iGATAudioThreadStreamOwner)
					{
						iGATAudioThreadStream = iGATAudioThreadStreamOwner.GetAudioThreadStream(0);
					}
					if (iGATAudioThreadStream == null)
					{
						Debug.LogWarning("Could not find IGATAudioThreadStream or IGATAudioThreadStreamOwner on GameObject " + observedAudioStreamComp.name);
						observedAudioStreamComp = _cachedStreamComp;
						return;
					}
				}
			}
			if (_observedStream != null)
			{
				_observedStream.RemoveAudioThreadStreamClient(this);
			}
			if (iGATAudioThreadStream != null)
			{
				iGATAudioThreadStream.AddAudioThreadStreamClient(this);
			}
			else
			{
				_dataIsUpdated = false;
				_needsData = true;
				HandleNoMoreData();
			}
			_observedStream = iGATAudioThreadStream;
			_cachedStreamComp = observedAudioStreamComp;
		}
	}
}
