using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

using SPACE_UTIL;

namespace GptDeepResearch
{
	public class PerScene_3 : MonoBehaviour
	{
		public TextMeshProUGUI tm;

		private void Awake()
		{
			StartCoroutine(tm.typewriter_effect(1f / 20));
		}
	}
}
