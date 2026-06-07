using System;
using System.Collections.Generic;
using Factory;
using NaughtyAttributes;
using UnityEngine;

namespace Motorways.UI.NewContentIndicators
{
	[CreateAssetMenu(menuName = "Motorways/UI/NewContentData")]
	public class NewContentData : ScriptableObject
	{
		[Dependency]
		private ActivePlayer _activePlayer;

		[Tooltip("If a new City needs to be added for NCIs, use this format for the ID below")]
		[ReadOnly]
		[SerializeField]
		private string _newCityNciIdFormat = "NewCity-{MapDefinition.cityName}";

		[SerializeField]
		private float _delayBetweenNciIntros;

		[SerializeField]
		private List<NewContentDataEntry> _entries;

		public float DelayBetweenNciIntros => _delayBetweenNciIntros;

		public event Action<string> onNewContentSeen;

		public bool IsNewContent(string newContentId, bool bypassNewContentData = false)
		{
			if (!Diagnostics.Verify(!string.IsNullOrWhiteSpace(newContentId)))
			{
				return false;
			}
			if (!bypassNewContentData)
			{
				NewContentDataEntry newContentDataEntry = _entries.Find((NewContentDataEntry entry) => entry.newContentId.Equals(newContentId));
				if (newContentDataEntry == null)
				{
					return false;
				}
				foreach (Feature requiredFeature in newContentDataEntry.requiredFeatures)
				{
					if (FeatureToggle.IsFeatureDisabled(requiredFeature))
					{
						return false;
					}
				}
			}
			return !_activePlayer.HasSeenNewContent(newContentId);
		}

		public void SetNewContentSeen(string newContentId)
		{
			_activePlayer.SetNewContentSeen(newContentId);
			this.onNewContentSeen?.Invoke(newContentId);
		}
	}
}
