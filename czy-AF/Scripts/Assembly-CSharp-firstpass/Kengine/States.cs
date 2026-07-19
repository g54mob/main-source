using System.Collections.Generic;
using UnityEngine;

namespace Kengine
{
	[AddComponentMenu("Kengine/Modifier/State")]
	public class States : MonoBehaviour
	{
		public int current;

		public List<State> stateList = new List<State>();

		private List<int> queue = new List<int>();

		public void Add(Vector3 _position, Vector3 _rotation, Vector3 _scale, bool _active = true, float _time = 0.2f, string _tween = "easeInOutSine")
		{
			stateList.Add(new State(_position, _rotation, _scale, _active, _time, _tween));
		}

		public void SetState(int s, bool clear = true)
		{
			if (clear)
			{
				queue.Clear();
			}
			_ = stateList[0];
			State state = stateList[s];
			base.transform.localPosition = state.position;
			base.transform.localEulerAngles = state.rotation;
			base.transform.localScale = state.scale;
			base.gameObject.SetActive(state.active);
			current = s;
		}

		public void AnimateState(int s, string tween = "", float time = -1f, bool clear = true)
		{
			if (clear)
			{
				queue.Clear();
			}
			if (tween == "")
			{
				tween = stateList[s].tween;
			}
			if (time == -1f)
			{
				time = stateList[s].time;
			}
			_ = stateList[0];
			State state = stateList[s];
			iTween.MoveTo(base.gameObject, iTween.Hash("time", time, "islocal", true, "ignoretimescale", true, "easetype", tween, "position", state.position, "onComplete", "nextState"));
			iTween.RotateTo(base.gameObject, iTween.Hash("time", time, "islocal", true, "ignoretimescale", true, "easetype", tween, "rotation", state.rotation));
			iTween.ScaleTo(base.gameObject, iTween.Hash("time", time, "islocal", true, "ignoretimescale", true, "easetype", tween, "scale", state.scale));
			base.gameObject.SetActive(state.active);
			current = s;
		}

		public void QueueStates(int[] states)
		{
			queue.Clear();
			foreach (int item in states)
			{
				queue.Add(item);
			}
			NextState();
		}

		public void QueueStop()
		{
			queue.Clear();
			ResetState();
		}

		public void NextState()
		{
			if (queue.Count > 0)
			{
				AnimateState(queue[0], stateList[queue[0]].tween, stateList[queue[0]].time, clear: false);
				queue.RemoveAt(0);
			}
		}

		public void ResetState()
		{
			SetState(0);
		}

		public int GetState()
		{
			return current;
		}
	}
}
