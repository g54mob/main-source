using System.Collections.Generic;
using UnityEngine;

namespace ARPGFX
{
	public class ARPGFXCycler : MonoBehaviour
	{
		[SerializeField]
		private List<GameObject> listOfEffects;

		[Header("Loop length in seconds")]
		[SerializeField]
		private float loopTimeLength;

		private float timeOfLastInstantiate;

		private GameObject instantiatedEffect;

		private int effectIndex;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
