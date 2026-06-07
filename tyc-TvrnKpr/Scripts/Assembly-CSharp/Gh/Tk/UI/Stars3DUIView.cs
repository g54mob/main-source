using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class Stars3DUIView : MonoBehaviour
	{
		[SerializeField]
		protected Transform[] _stars;

		[SerializeField]
		protected GameObject _leftHalfStarPrefab;

		[SerializeField]
		protected GameObject _starPrefab;

		protected List<GameObject> _instantiatedStars;

		protected int _rating;

		public virtual void SetValue(float rating)
		{
		}
	}
}
