using TMPEffects.Components;
using UnityEngine;
using UnityEngine.Playables;

namespace TMPEffects.Timeline.Markers
{
	[RequireComponent(typeof(TMPWriter))]
	public class TMPWriterMarkReceiver : MonoBehaviour, INotificationReceiver
	{
		private TMPWriter writer;

		public void OnNotify(Playable origin, INotification notification, object context)
		{
			if (writer == null)
			{
				writer = GetComponent<TMPWriter>();
				if (writer == null)
				{
					return;
				}
			}
			if (!(notification is TMPStartWriterMarker))
			{
				if (!(notification is TMPStopWriterMarker))
				{
					if (!(notification is TMPResetWriterMarker tMPResetWriterMarker))
					{
						if (!(notification is TMPSkipWriterMarker tMPSkipWriterMarker))
						{
							if (!(notification is TMPRestartWriterMarker))
							{
								if (!(notification is TMPWriterWaitMarker tMPWriterWaitMarker))
								{
									if (!(notification is TMPWriterSetSkippableMarker tMPWriterSetSkippableMarker))
									{
										if (notification is TMPWriterResetWaitMarker)
										{
											writer.ResetWaitPeriod();
										}
									}
									else
									{
										writer.SetSkippable(tMPWriterSetSkippableMarker.Skippable);
									}
								}
								else
								{
									writer.Wait(tMPWriterWaitMarker.WaitTime);
								}
							}
							else
							{
								writer.RestartWriter();
							}
						}
						else
						{
							writer.SkipWriter(tMPSkipWriterMarker.SkipShowAnimation);
						}
					}
					else
					{
						writer.ResetWriter(tMPResetWriterMarker.TextIndex);
					}
				}
				else
				{
					writer.StopWriter();
				}
			}
			else
			{
				writer.StartWriter();
			}
		}
	}
}
