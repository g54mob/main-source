using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Events
{
	[CreateAssetMenu(menuName = "Malbers Animations/Event", fileName = "New Event Asset", order = 3000)]
	public class MEvent : ScriptableObject
	{
		internal readonly List<MEventItemListener> eventListeners = new List<MEventItemListener>();

		public bool debug;

		public virtual void Invoke()
		{
			for (int num = eventListeners.Count - 1; num >= 0; num--)
			{
				eventListeners[num].OnEventInvoked();
			}
		}

		public virtual void Invoke(float value)
		{
			DebugEvent($"{value:F2}", "float");
			for (int num = eventListeners.Count - 1; num >= 0; num--)
			{
				eventListeners[num].OnEventInvoked(value);
			}
		}

		public virtual void InvokeToInt(float value)
		{
			DebugEvent(value, "float to int");
			for (int num = eventListeners.Count - 1; num >= 0; num--)
			{
				eventListeners[num].OnEventInvoked((int)value);
			}
		}

		public virtual void InvokeToFloat(int value)
		{
			DebugEvent(value, "int to float");
			for (int num = eventListeners.Count - 1; num >= 0; num--)
			{
				eventListeners[num].OnEventInvoked((float)value);
			}
		}

		public virtual void Invoke(FloatVar value)
		{
			DebugEvent(value, "Float Var");
			for (int num = eventListeners.Count - 1; num >= 0; num--)
			{
				eventListeners[num].OnEventInvoked(value.Value);
			}
		}

		public virtual void Invoke(bool value)
		{
			DebugEvent(value, "bool");
			for (int num = eventListeners.Count - 1; num >= 0; num--)
			{
				eventListeners[num].OnEventInvoked(value);
			}
		}

		public virtual void Invoke(BoolVar value)
		{
			DebugEvent(value.Value, "Bool Var");
			for (int num = eventListeners.Count - 1; num >= 0; num--)
			{
				eventListeners[num].OnEventInvoked(value.Value);
			}
		}

		public virtual void Invoke(string value)
		{
			DebugEvent("'" + value + "'", "string");
			for (int num = eventListeners.Count - 1; num >= 0; num--)
			{
				eventListeners[num].OnEventInvoked(value);
			}
		}

		public virtual void Invoke(StringVar value)
		{
			DebugEvent(value.Value, "StringVar");
			for (int num = eventListeners.Count - 1; num >= 0; num--)
			{
				eventListeners[num].OnEventInvoked(value.Value);
			}
		}

		public virtual void Invoke(int value)
		{
			DebugEvent(value, "int");
			for (int num = eventListeners.Count - 1; num >= 0; num--)
			{
				eventListeners[num].OnEventInvoked(value);
			}
		}

		public virtual void Invoke(IntVar value)
		{
			DebugEvent(value.Value, "Int Var");
			for (int num = eventListeners.Count - 1; num >= 0; num--)
			{
				eventListeners[num].OnEventInvoked(value.Value);
			}
		}

		public virtual void Invoke(IDs value)
		{
			DebugEvent($"({value.name} - {value.ID})", "Int[ID]");
			for (int num = eventListeners.Count - 1; num >= 0; num--)
			{
				eventListeners[num].OnEventInvoked(value.ID);
			}
		}

		public virtual void Invoke(GameObject value)
		{
			DebugEvent(value, "GameObject");
			for (int num = eventListeners.Count - 1; num >= 0; num--)
			{
				eventListeners[num].OnEventInvoked(value);
			}
		}

		public virtual void Invoke(GameObjectVar value)
		{
			Invoke(value.Value);
		}

		public virtual void Invoke(Transform value)
		{
			DebugEvent((value != null) ? value.name : null, "Transform");
			for (int num = eventListeners.Count - 1; num >= 0; num--)
			{
				eventListeners[num].OnEventInvoked(value);
			}
		}

		public virtual void Invoke(TransformVar value)
		{
			Invoke(value.Value);
		}

		public virtual void Invoke(Vector3 value)
		{
			DebugEvent(value, "Vector3");
			for (int num = eventListeners.Count - 1; num >= 0; num--)
			{
				eventListeners[num].OnEventInvoked(value);
			}
		}

		public virtual void Invoke(Vector3Var value)
		{
			Invoke(value.Value);
		}

		public virtual void Invoke(Vector2 value)
		{
			DebugEvent(value, "Vector2");
			for (int num = eventListeners.Count - 1; num >= 0; num--)
			{
				eventListeners[num].OnEventInvoked(value);
			}
		}

		public virtual void Invoke(Component value)
		{
			DebugEvent(value, "Component");
			for (int num = eventListeners.Count - 1; num >= 0; num--)
			{
				eventListeners[num].OnEventInvoked(value);
			}
		}

		public virtual void Invoke(Sprite value)
		{
			DebugEvent(value, "Sprite");
			for (int num = eventListeners.Count - 1; num >= 0; num--)
			{
				eventListeners[num].OnEventInvoked(value);
			}
		}

		public virtual void Invoke(SpriteVar value)
		{
			Invoke(value.Value);
		}

		public virtual void RegisterListener(MEventItemListener listener)
		{
			if (!eventListeners.Contains(listener))
			{
				eventListeners.Add(listener);
			}
		}

		public virtual void UnregisterListener(MEventItemListener listener)
		{
			if (eventListeners.Contains(listener))
			{
				eventListeners.Remove(listener);
			}
		}

		public virtual void InvokeAsGameObject(Component value)
		{
			Invoke((value != null) ? value.gameObject : null);
		}

		public virtual void InvokeAsTransform(GameObject value)
		{
			Invoke((value != null) ? value.transform : null);
		}

		public virtual void InvokeAsTransform(Component value)
		{
			Invoke((value != null) ? value.transform : null);
		}

		public virtual void InvokeAsString(Object value)
		{
			Invoke((value != null) ? value.name.Replace("(Clone)", "") : string.Empty);
		}

		public virtual void InvokeAsBool(Object value)
		{
			Invoke(value != null);
		}

		public virtual void InvokeAsBool(int value)
		{
			Invoke(value > 0);
		}

		public virtual void InvokeAsFloat(bool value)
		{
			Invoke(value ? 1 : 0);
		}

		public virtual void InvokeAsInt(bool value)
		{
			Invoke(value ? 1 : 0);
		}

		public virtual void InvokeAsInt(Object value)
		{
			Invoke((value != null) ? value.GetInstanceID() : (-1));
		}

		private void DebugEvent(object value, string type)
		{
		}

		public void LogDeb(int value, int value2)
		{
			LogDeb((object)value, (object)value2);
		}

		public void LogDeb(object value, object value2)
		{
		}

		public virtual void Pause()
		{
			Debug.Log("Pause Editor", this);
			Debug.Break();
		}

		public virtual void LogDeb(string value)
		{
			Debug.Log("<color=white><B>" + base.name + " : [" + value + "] </B></color>", this);
		}

		public virtual void LogDeb(bool value)
		{
			Debug.Log($"<color=white><B>{base.name} : [{value}] </B></color>");
		}

		public virtual void LogDeb(Vector3 value)
		{
			Debug.Log($"<color=white><B>{base.name} : [{value}] </B></color>");
		}

		public virtual void LogDeb(Vector2 value)
		{
			Debug.Log($"<color=white><B>{base.name} : [{value}] </B></color>");
		}

		public virtual void LogDeb(int value)
		{
			Debug.Log($"<color=white><B>{base.name} : [{value}] </B></color>");
		}

		public virtual void LogDeb(float value)
		{
			Debug.Log($"<color=white><B>{base.name} : [{value}] </B></color>");
		}

		public virtual void LogDeb(object value)
		{
			Debug.Log($"<color=white><B>{base.name} : [{value}] </B></color>");
		}

		public virtual void LogDeb(Object value)
		{
			Debug.Log($"<color=white><B>{base.name} : [{value}] </B></color>");
		}
	}
}
