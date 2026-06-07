using UnityEngine;

namespace GAudio
{
	public abstract class AGATStreamObserver : MonoBehaviour
	{
		public Component streamComponent;

		public bool streamIsTrack;

		public int streamIndex;

		protected IGATAudioThreadStream _stream;

		protected virtual void Start()
		{
			if (_stream != null)
			{
				return;
			}
			try
			{
				GetStream();
			}
			catch (GATException ex)
			{
				base.enabled = false;
				Debug.LogError("No stream found! " + ex.Message);
			}
		}

		protected void GetStream()
		{
			if (streamComponent == null)
			{
				streamComponent = base.gameObject.GetComponent(typeof(IGATAudioThreadStreamOwner));
			}
			if (streamIsTrack)
			{
				GATPlayer gATPlayer = streamComponent as GATPlayer;
				if (gATPlayer == null)
				{
					throw new GATException("Cannot find GATPlayer to observe track stream. ");
				}
				if (streamIndex >= gATPlayer.NbOfTracks)
				{
					throw new GATException("Track does not exist!");
				}
				GATTrack track = gATPlayer.GetTrack(streamIndex);
				_stream = track.GetAudioThreadStream();
			}
			else
			{
				IGATAudioThreadStreamOwner iGATAudioThreadStreamOwner = streamComponent as IGATAudioThreadStreamOwner;
				_stream = iGATAudioThreadStreamOwner.GetAudioThreadStream(streamIndex);
				if (iGATAudioThreadStreamOwner == null)
				{
					throw new GATException("Component is not a stream!");
				}
				if (streamIndex >= iGATAudioThreadStreamOwner.NbOfStreams)
				{
					throw new GATException("Requested stream index does not exist.");
				}
			}
		}
	}
}
