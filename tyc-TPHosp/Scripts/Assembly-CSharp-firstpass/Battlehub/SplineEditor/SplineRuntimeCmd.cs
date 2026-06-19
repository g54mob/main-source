using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Battlehub.RTEditor;
using UnityEngine;

namespace Battlehub.SplineEditor
{
	public class SplineRuntimeCmd : MonoBehaviour
	{
		public Spline m_spline;

		public SplineControlPoint m_controlPoint;

		private Spline GetSelectedSpline()
		{
			if (RuntimeSelection.activeGameObject == null)
			{
				return null;
			}
			return RuntimeSelection.activeGameObject.GetComponentInParent<Spline>();
		}

		private SplineControlPoint GetSelectedControlPoint()
		{
			if (RuntimeSelection.activeGameObject == null)
			{
				return null;
			}
			return RuntimeSelection.activeGameObject.GetComponentInParent<SplineControlPoint>();
		}

		public void Awake()
		{
			m_spline = GetSelectedSpline();
			RuntimeSelection.SelectionChanged += OnRuntimeSelectionChanged;
		}

		public void OnDestroy()
		{
			SplineBase.ConvergingSpline = null;
			RuntimeSelection.SelectionChanged -= OnRuntimeSelectionChanged;
		}

		private void OnRuntimeSelectionChanged(UnityEngine.Object[] unselectedObjects)
		{
			if ((bool)SplineBase.ConvergingSpline)
			{
				SplineControlPoint selectedControlPoint = GetSelectedControlPoint();
				Spline selectedSpline = GetSelectedSpline();
				if (selectedControlPoint == null || m_controlPoint == null || m_spline == null)
				{
					SplineBase.ConvergingSpline = null;
				}
				else if (Converge(selectedSpline, m_spline, selectedControlPoint.Index, m_controlPoint.Index))
				{
					SplineBase.ConvergingSpline = null;
					m_spline = selectedSpline;
					m_controlPoint = selectedControlPoint;
				}
				else
				{
					SplineBase.ConvergingSpline = null;
				}
			}
			else
			{
				m_controlPoint = GetSelectedControlPoint();
				m_spline = GetSelectedSpline();
			}
		}

		public void RunAction<T>(Action<T, GameObject> action)
		{
			GameObject[] gameObjects = RuntimeSelection.gameObjects;
			if (gameObjects == null)
			{
				return;
			}
			foreach (GameObject gameObject in gameObjects)
			{
				if (!(gameObject == null))
				{
					T componentInParent = gameObject.GetComponentInParent<T>();
					if (componentInParent != null)
					{
						action?.Invoke(componentInParent, gameObject);
					}
				}
			}
		}

		public virtual void Append()
		{
			RunAction(delegate(Spline spline, GameObject go)
			{
				if (spline.NextSpline == null)
				{
					spline.Append();
				}
			});
		}

		public virtual void Insert()
		{
			RunAction(delegate(Spline spline, GameObject go)
			{
				if (go != null)
				{
					SplineControlPoint component = go.GetComponent<SplineControlPoint>();
					if (component != null)
					{
						spline.Insert((component.Index + 2) / 3);
					}
				}
			});
		}

		public virtual void Prepend()
		{
			RunAction(delegate(Spline spline, GameObject go)
			{
				if (spline.PrevSpline == null)
				{
					spline.Prepend();
				}
			});
		}

		public virtual void Remove()
		{
			RunAction(delegate(Spline spline, GameObject go)
			{
				if (go != null)
				{
					SplineControlPoint component = go.GetComponent<SplineControlPoint>();
					if (component != null)
					{
						int curveIndex = Mathf.Min((component.Index + 1) / 3, spline.CurveCount - 1);
						spline.Remove(curveIndex);
					}
					RuntimeSelection.activeObject = spline.gameObject;
				}
			});
		}

		public virtual void Smooth()
		{
			RunAction(delegate(SplineBase spline, GameObject go)
			{
				spline.Root.Smooth();
			});
		}

		public virtual void SetMirroredMode()
		{
			RunAction(delegate(SplineBase spline, GameObject go)
			{
				spline.Root.SetControlPointMode(ControlPointMode.Mirrored);
			});
		}

		public virtual void SetAlignedMode()
		{
			RunAction(delegate(SplineBase spline, GameObject go)
			{
				spline.Root.SetControlPointMode(ControlPointMode.Aligned);
			});
		}

		public virtual void SetFreeMode()
		{
			RunAction(delegate(SplineBase spline, GameObject go)
			{
				spline.Root.SetControlPointMode(ControlPointMode.Free);
			});
		}

		public virtual void OutBranch()
		{
			throw new NotImplementedException("Implement after Save/Load enchancements");
		}

		public virtual void BranchIn()
		{
			throw new NotImplementedException("Implement after Save/Load enchancements");
		}

		public virtual void Converge()
		{
			SplineBase.ConvergingSpline = m_spline;
		}

		public virtual void Separate()
		{
			if (m_spline != null && m_controlPoint != null)
			{
				Separate(m_spline, m_controlPoint.Index);
			}
		}

		public static bool Converge(SplineBase spline, SplineBase branch, int splineIndex, int branchIndex)
		{
			if (spline == branch)
			{
				return false;
			}
			if (branch.PrevSpline != null && branch.NextSpline != null)
			{
				return false;
			}
			if (branchIndex == 0)
			{
				if (branch.PrevSpline != null)
				{
					return false;
				}
				spline.SetBranch(branch, splineIndex, isInbound: false);
				return true;
			}
			if (branchIndex == branch.ControlPointCount - 1)
			{
				if (branch.NextSpline != null)
				{
					return false;
				}
				spline.SetBranch(branch, splineIndex, isInbound: true);
				return true;
			}
			Debug.LogError("branchIndex should be equal to 0 or branch.ControlPointCount - 1");
			return false;
		}

		public static void Separate(SplineBase spline, int controlPointIndex)
		{
			spline.Unselect();
			spline.Disconnect(controlPointIndex);
			spline.Select();
		}

		public virtual void Load()
		{
			string text = PlayerPrefs.GetString("SplineEditorSave");
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			SplineBase[] array = UnityEngine.Object.FindObjectsOfType<SplineBase>();
			SplineSnapshot[] array2 = DeserializeFromString<SplineSnapshot[]>(text);
			if (array.Length != array2.Length)
			{
				Debug.LogError("Wrong data in save file");
				return;
			}
			for (int i = 0; i < array2.Length; i++)
			{
				array[i].Load(array2[i]);
			}
		}

		public virtual void Save()
		{
			SplineBase[] array = UnityEngine.Object.FindObjectsOfType<SplineBase>();
			SplineSnapshot[] array2 = new SplineSnapshot[array.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = array[i].Save();
			}
			string value = SerializeToString(array2);
			PlayerPrefs.SetString("SplineEditorSave", value);
		}

		private static TData DeserializeFromString<TData>(string settings)
		{
			using MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(settings));
			SurrogateSelector surrogateSelector = new SurrogateSelector();
			Vector3SerializationSurrogate surrogate = new Vector3SerializationSurrogate();
			surrogateSelector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), surrogate);
			BinaryFormatter obj = new BinaryFormatter
			{
				SurrogateSelector = surrogateSelector
			};
			memoryStream.Seek(0L, SeekOrigin.Begin);
			return (TData)obj.Deserialize(memoryStream);
		}

		private static string SerializeToString<TData>(TData settings)
		{
			using MemoryStream memoryStream = new MemoryStream();
			SurrogateSelector surrogateSelector = new SurrogateSelector();
			Vector3SerializationSurrogate surrogate = new Vector3SerializationSurrogate();
			surrogateSelector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), surrogate);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.SurrogateSelector = surrogateSelector;
			binaryFormatter.Serialize(memoryStream, settings);
			memoryStream.Flush();
			memoryStream.Position = 0L;
			return Convert.ToBase64String(memoryStream.ToArray());
		}
	}
}
