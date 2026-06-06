using System;
using System.Collections;
using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public class MSpeedSet : IComparable, IComparer
	{
		[Tooltip("Name of the Speed Set")]
		public string name;

		[Tooltip("Which Speed the Set will start, This value is the Index for the Speed Modifier List, Starting the first index with (1) instead of (0)")]
		public IntReference StartVerticalIndex;

		[Tooltip("Set the Top Index when Increasing the Speed using SpeedUP")]
		public IntReference TopIndex;

		[Tooltip("Index Value of the Sprint Speed")]
		public IntReference m_SprintIndex = new IntReference(10);

		[Tooltip("When the Speed is locked this will be the value s")]
		public IntReference m_LockIndex = new IntReference(1);

		[Tooltip("Lock the Speed Set to Certain Value")]
		public BoolReference m_LockSpeed = new BoolReference(value: false);

		[Tooltip("RootMotion multiplier for the speeds Position. Set it to zero to remove RootMotion movement")]
		public FloatReference m_RootMotionPos = new FloatReference(1f);

		[Tooltip("RootMotion multiplier for the speeds Rotation. Set it to zero to remove RootMotion Rotation")]
		public FloatReference m_RootMotionRot = new FloatReference(1f);

		[Tooltip("Backwards Speed multiplier: When going backwards the speed will be decreased by this value")]
		public FloatReference BackSpeedMult = new FloatReference(0.5f);

		[Tooltip("Lerp used to Activate the FreeMovement")]
		public FloatReference PitchLerpOn = new FloatReference(10f);

		[Tooltip("Lerp used to Deactivate the FreeMovement")]
		public FloatReference PitchLerpOff = new FloatReference(10f);

		[Tooltip("Lerp used to for the Banking on FreeMovement")]
		public FloatReference BankLerp = new FloatReference(10f);

		[Tooltip("Up Down Multiplier ")]
		public FloatReference UpDownMult = new FloatReference(1f);

		[Tooltip("States that will use the Speed Set")]
		public List<StateID> states;

		[Tooltip("Stances that will use the Speed Set")]
		public List<StanceID> stances;

		public List<MSpeed> Speeds;

		public bool HasStances
		{
			get
			{
				if (stances != null)
				{
					return stances.Count > 0;
				}
				return false;
			}
		}

		public int CurrentIndex { get; set; }

		public int LockIndex
		{
			get
			{
				return m_LockIndex.Value;
			}
			set
			{
				m_LockIndex.Value = value;
			}
		}

		public int SprintIndex
		{
			get
			{
				return m_SprintIndex.Value;
			}
			set
			{
				m_SprintIndex.Value = value;
			}
		}

		public float RootMotionPos
		{
			get
			{
				return m_RootMotionPos.Value;
			}
			set
			{
				m_RootMotionPos.Value = value;
			}
		}

		public float RootMotionRot
		{
			get
			{
				return m_RootMotionRot.Value;
			}
			set
			{
				m_RootMotionRot.Value = value;
			}
		}

		public bool LockSpeed
		{
			get
			{
				return m_LockSpeed.Value;
			}
			set
			{
				m_LockSpeed.Value = value;
				if (value)
				{
					LockedSpeedModifier = Speeds[Mathf.Clamp(LockIndex - 1, 0, Speeds.Count - 1)];
				}
			}
		}

		public MSpeed LockedSpeedModifier { get; set; }

		public MSpeed this[int index]
		{
			get
			{
				return Speeds[index];
			}
			set
			{
				Speeds[index] = value;
			}
		}

		public MSpeed this[string name] => Speeds.Find((MSpeed x) => x.name == name);

		public MSpeedSet()
		{
			name = "Set Name";
			states = new List<StateID>();
			StartVerticalIndex = new IntReference(1);
			TopIndex = new IntReference(2);
			Speeds = new List<MSpeed>(1)
			{
				new MSpeed("SpeedName", 1f, 4f, 4f)
			};
		}

		public bool HasStance(int stance)
		{
			if (!HasStances)
			{
				return true;
			}
			return stances.Find((StanceID s) => s.ID == stance);
		}

		public int Compare(object x, object y)
		{
			bool hasStances = (x as MSpeedSet).HasStances;
			bool hasStances2 = (y as MSpeedSet).HasStances;
			if (hasStances && hasStances2)
			{
				return 0;
			}
			if (hasStances && !hasStances2)
			{
				return 1;
			}
			return -1;
		}

		public int CompareTo(object obj)
		{
			bool hasStances = (obj as MSpeedSet).HasStances;
			bool hasStances2 = HasStances;
			if (hasStances && hasStances2)
			{
				return 0;
			}
			if (hasStances && !hasStances2)
			{
				return 1;
			}
			return -1;
		}

		public MSpeed GetSpeed(string name)
		{
			return Speeds.Find((MSpeed x) => x.name == name);
		}

		public int GetSpeedIndex(string name)
		{
			return Speeds.FindIndex((MSpeed x) => x.name == name);
		}

		internal void SwapSpeed(MSpeed NewSpeed)
		{
			int speedIndex = GetSpeedIndex(NewSpeed.Name);
			Debug.Log($"speedIndex : {speedIndex}");
			if (speedIndex != -1)
			{
				Speeds[speedIndex] = NewSpeed;
			}
		}

		internal void AddSpeed(MSpeed NewSpeed)
		{
			Speeds.Add(NewSpeed);
		}
	}
}
