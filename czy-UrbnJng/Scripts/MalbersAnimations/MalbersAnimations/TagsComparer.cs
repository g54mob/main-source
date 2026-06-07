using System;
using MalbersAnimations.Events;
using UnityEngine;

namespace MalbersAnimations
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/secondary-components/scriptables/tags")]
	[AddComponentMenu("Malbers/Utilities/Tools/Tags Comparer")]
	public class TagsComparer : MonoBehaviour
	{
		[Serializable]
		public class TagComparerResponse
		{
			public Tag tag;

			public GameObjectEvent HasTag = new GameObjectEvent();
		}

		public bool CheckInParent = true;

		public TagComparerResponse[] tags;

		public void Evaluate(GameObject gameObject)
		{
			TagComparerResponse[] array = tags;
			foreach (TagComparerResponse tagComparerResponse in array)
			{
				if ((CheckInParent && gameObject.HasMalbersTagInParent(tagComparerResponse.tag)) || gameObject.HasMalbersTag(tagComparerResponse.tag))
				{
					tagComparerResponse.HasTag.Invoke(gameObject);
				}
			}
		}

		public void Evaluate(Component co)
		{
			Evaluate(co.gameObject);
		}
	}
}
