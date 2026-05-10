using System.Collections.Generic;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class VictoryScreenActorSpineLinker : MonoBehaviour
	{
		[SerializeField]
		private SerializableDictionary<EActors, GameObject> _actors = new SerializableDictionary<EActors, GameObject>();

		[SerializeField]
		private ActorsColorData _actorsColorData;

		[SerializeField]
		private Image _backgroundImage;

		private GameObject _currentActorShowing;

		private void OnEnable()
		{
			HideAll();
		}

		[Button(null, EButtonEnableMode.Always)]
		public void HideShowing()
		{
			_currentActorShowing.SetActive(value: false);
			_currentActorShowing = null;
		}

		public void ShowingTheVictorySplinePersonna(EActors VictoryScreenPersonna)
		{
			foreach (KeyValuePair<EActors, GameObject> actor in _actors)
			{
				if (actor.Key == VictoryScreenPersonna)
				{
					_currentActorShowing = actor.Value;
					_backgroundImage.color = _actorsColorData.Actors[actor.Key];
					_currentActorShowing.SetActive(value: true);
					break;
				}
			}
		}

		public void HideAll()
		{
			foreach (KeyValuePair<EActors, GameObject> actor in _actors)
			{
				actor.Value.SetActive(value: false);
			}
		}
	}
}
