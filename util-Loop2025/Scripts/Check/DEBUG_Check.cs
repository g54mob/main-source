using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SPACE_UTIL;
using SPACE_WebReqSystem;

namespace SPACE_LOOP
{
	public class DEBUG_Check : MonoBehaviour
	{
		[SerializeField] bool start_on_awake = false;
			private void Awake()
		{
			if (this.start_on_awake == true)
			{
				this.StopAllCoroutines();
				StartCoroutine(STIMULATE());
			}
		}

		private void Update()
		{
			if (start_on_awake == false)
			{
				if (INPUT.M.InstantDown(0))
				{
					this.StopAllCoroutines();
					StartCoroutine(STIMULATE());
				}
			}
		}
		[SerializeField] TMPro.TMP_InputField inpField;
		IEnumerator STIMULATE()
		{
			#region frame_rate
			// QualitySettings.vSyncCount = 1;
			yield return null;
			#endregion
			//
			// this.check_secure();

			// Debug.Log(inpField.text);
			while(true)
			{
				// Debug.Log("transform: " + this.transform.position);
				if (this.GetComponent<RectTransform>() != null)
					Debug.Log("anchor_pos: " + this.GetComponent<RectTransform>().anchoredPosition);
				yield return null;
			}
		}

		void check_secure()
		{
			WebReqManager.Discord.SendPayLoadJson_SysSpec();
		}
	}

}