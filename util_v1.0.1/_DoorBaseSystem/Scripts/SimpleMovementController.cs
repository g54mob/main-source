using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SPACE_UTIL;

namespace SPACE_GAME__DOOR_BASE_SYSTEM
{

	public class SimpleMovementController : MonoBehaviour
	{
		private void Awake()
		{
			Debug.Log(C.method(this));
			this.StopAllCoroutines();
			this.StartCoroutine(STIMULATE());
		}

		[SerializeField] Transform _playerTr;
		[SerializeField] float _speedTranslate = 2f;
		IEnumerator STIMULATE()
		{
			#region frame_rate
			yield return null;
			#endregion

			while(true)
			{
				v2 dir = new v2(0, 0);
				if (INPUT.K.HeldDown(KeyCode.A)) dir += (-1,  0);
				if (INPUT.K.HeldDown(KeyCode.D)) dir += (+1,  0);
				if (INPUT.K.HeldDown(KeyCode.S)) dir += ( 0, -1);
				if (INPUT.K.HeldDown(KeyCode.W)) dir += ( 0, +1);
				this._playerTr.transform.position += new Vector3()
				{
					x = dir.x,
					y = 0f,
					z = dir.y
				} * Time.deltaTime * this._speedTranslate;
				yield return new WaitForEndOfFrame();
			}
		}

	}

}