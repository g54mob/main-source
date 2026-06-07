using System.Collections;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainScene.Scripts
{
	public class ShowExitButton : MonoBehaviour
	{
		public TweenPosition ButtonTween;

		private bool _allCompleted;

		public void Start()
		{
			StartCoroutine(UpdateMissionStatus());
		}

		public IEnumerator UpdateMissionStatus()
		{
			while (true)
			{
				if (_allCompleted || (SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission != null && (SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission.IsCompleted() || SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission.IsFailed())))
				{
					ButtonTween.Play(true);
					_allCompleted = true;
				}
				yield return new WaitForSeconds(0.1f);
			}
		}
	}
}
