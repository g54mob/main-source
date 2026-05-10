using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPACE_UTIL;

namespace SPACE__DOOR_BASE_SYSTEM
{
	public class DoorAutoOpenCloseTrigger : MonoBehaviour
	{
		[TextArea(minLines: 2, maxLines: 3)]
		[SerializeField] string README = @"0. gotta have rigidBody component attached for player.
1. gameObject.name.isAnyMatch(""player"");";
		[SerializeField] List<GameObject> insideTheTrigger = new List<GameObject>();

		private void OnTriggerEnter(Collider other)
		{
			Debug.Log(C.method(this, "cyan"));
			this.insideTheTrigger.Add(other.gameObject);

			if (other.gameObject.name.isAnyMatch(@"player")) // player 
			{
				DoorBase doorBase = this.gameObject.Q().upCompoGf<DoorBase>();
				Debug.Log(doorBase);
				doorBase.TryOpen();
			}
		}
		private void OnTriggerExit(Collider other)
		{
			Debug.Log(C.method(this, "cyan"));
			this.insideTheTrigger.Remove(other.gameObject);

			if (this.insideTheTrigger.Count == 0)
				if (other.gameObject.name.isAnyMatch(@"player")) // player
				{
					DoorBase doorBase = this.gameObject.Q().upCompoGf<DoorBase>();
					Debug.Log(doorBase);
					doorBase.TryClose();
				}
		}
	}
}
