using System.Collections.Generic;
using UnityEngine;

namespace DG.Tweening.Timeline
{
	public class DOTweenClipCollection : MonoBehaviour
	{
		[HideInInspector]
		public bool killTweensOnDestroy;

		public DOTweenClip[] clips;

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		public void PlayAll(bool restartIfExists = true)
		{
		}

		public DOTweenClip GetClipByName(string clipName)
		{
			return null;
		}

		public List<DOTweenClip> GetClipsByName(string clipName)
		{
			return null;
		}

		public void GetClipsByName(string clipName, ref List<DOTweenClip> fillList)
		{
		}

		public void KillAllTweens(bool complete = false)
		{
		}

		public void RewindAllTweens(bool includeDelay = true)
		{
		}

		public void CompleteAllTweens(bool withCallbacks = false)
		{
		}

		public void RestartAllTweens(bool includeDelay = true)
		{
		}

		public void RestartAllTweens(bool includeDelay, float changeDelayTo)
		{
		}

		public void RestartAllTweensFromHere(bool includeDelay = true)
		{
		}

		public void RestartAllTweensFromHere(bool includeDelay, float changeDelayTo)
		{
		}

		public void PauseAllTweens()
		{
		}

		public void PlayAllTweens()
		{
		}

		public void PlayAllTweensBackwards()
		{
		}

		public void PlayAllTweensForward()
		{
		}
	}
}
