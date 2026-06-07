using System;
using System.Collections.Generic;
using UnityEngine;

public class Junction : MonoBehaviour
{
	[Serializable]
	public struct JunctionData
	{
		[Flags]
		public enum DataDifferenceType
		{
			None = 0,
			Position = 1,
			JunctionId = 2,
			JunctionIndex = 4,
			JunctionType = 8,
			Exclusion = 0x10,
			Links = 0x20
		}

		public const string ID_MARKER_NONE = "None";

		public const string ID_MARKER_WORLD = "W";

		public const string ID_MARKER_STATION = "S";

		public const string ID_MARKER_ROUTE_MAP_EXCLUDED = "EXC";

		public const string ID_DELIMITER = "-";

		public int junctionIndex;

		public int junctionId;

		public string junctionIdLong;

		public Vector3 position;

		public bool excludeFromJunctionMap;

		public bool isValid;

		public List<int> linkedJunctions;

		public DataDifferenceType DataDifference(JunctionData other)
		{
			DataDifferenceType dataDifferenceType = DataDifferenceType.None;
			if (junctionId != other.junctionId)
			{
				dataDifferenceType |= DataDifferenceType.JunctionId;
			}
			if (junctionIndex != other.junctionIndex)
			{
				dataDifferenceType |= DataDifferenceType.JunctionIndex;
			}
			if (!ApproxSamePosition(this, other))
			{
				dataDifferenceType |= DataDifferenceType.Position;
			}
			bool num = junctionIdLong.StartsWith("S");
			bool flag = other.junctionIdLong.StartsWith("S");
			if (num != flag)
			{
				dataDifferenceType |= DataDifferenceType.JunctionType;
			}
			if (excludeFromJunctionMap != other.excludeFromJunctionMap)
			{
				dataDifferenceType |= DataDifferenceType.Exclusion;
			}
			HashSet<int> obj = ((linkedJunctions != null) ? new HashSet<int>(linkedJunctions) : new HashSet<int>());
			HashSet<int> hashSet = ((other.linkedJunctions != null) ? new HashSet<int>(other.linkedJunctions) : new HashSet<int>());
			if (!obj.SetEquals(hashSet))
			{
				dataDifferenceType |= DataDifferenceType.Links;
			}
			return dataDifferenceType;
		}

		private bool ApproxSamePosition(JunctionData a, JunctionData b)
		{
			Vector3 vector = a.position - b.position;
			vector.y = 0f;
			return vector.sqrMagnitude < 1f;
		}
	}

	public enum SwitchMode : byte
	{
		REGULAR = 0,
		FORCED = 1,
		NO_SOUND = 2
	}

	[Serializable]
	public class Branch
	{
		[SerializeField]
		public RailTrack track;

		[SerializeField]
		public bool first;

		public bool EqualsFields(Branch branch)
		{
			if (track == branch.track)
			{
				return first == branch.first;
			}
			return false;
		}

		public Branch()
		{
		}

		public Branch(RailTrack track, bool first)
		{
			this.track = track;
			this.first = first;
		}

		public BezierPoint GetBezierPoint()
		{
			if (!track)
			{
				return null;
			}
			if (first)
			{
				return track.curve[0];
			}
			return track.curve.Last();
		}

		public Transform GetNode()
		{
			if (!track)
			{
				return null;
			}
			if (first)
			{
				return track.curve[0].transform;
			}
			return track.curve.Last().transform;
		}
	}

	public JunctionData junctionData;

	public short defaultSelectedBranch = -1;

	public Branch inBranch;

	public List<Branch> outBranches = new List<Branch>();

	public byte selectedBranch;

	public Vector3 position => base.transform.position;

	public event Action<SwitchMode, int> Switched;

	private void Awake()
	{
		defaultSelectedBranch = selectedBranch;
	}

	public void Switch(SwitchMode mode)
	{
		Switch(mode, (byte)(selectedBranch + 1));
	}

	public void Switch(SwitchMode mode, byte branch)
	{
		branch = (byte)(branch % outBranches.Count);
		selectedBranch = branch;
		this.Switched?.Invoke(mode, selectedBranch);
	}

	public bool HasInBranch(Branch branch)
	{
		if (inBranch == null)
		{
			return false;
		}
		return inBranch.EqualsFields(branch);
	}

	public bool HasOutBranch(Branch branch)
	{
		foreach (Branch outBranch in outBranches)
		{
			if (outBranch != null && outBranch.EqualsFields(branch))
			{
				return true;
			}
		}
		return false;
	}

	public bool HasBranch(Branch branch)
	{
		if (!HasInBranch(branch))
		{
			return HasOutBranch(branch);
		}
		return true;
	}

	private Vector3 GetNodePosition(Branch branch)
	{
		if (branch == null)
		{
			return base.transform.position;
		}
		if (branch.track == null)
		{
			return base.transform.position;
		}
		if (branch.first)
		{
			return branch.track.curve[0].position;
		}
		return branch.track.curve.Last().position;
	}

	public Branch GetNextBranch(RailTrack currentTrack, bool first)
	{
		Branch branch = new Branch(currentTrack, first);
		if ((bool)inBranch.track && inBranch.EqualsFields(branch))
		{
			if (outBranches.Count == 0)
			{
				Debug.LogWarning("The junction has no out branches", this);
				return null;
			}
			if (outBranches[selectedBranch] == null || outBranches[selectedBranch].track == null)
			{
				Debug.LogError("Invalid next branch. Possibly track does not exist on a branch", this);
				return null;
			}
			return outBranches[selectedBranch];
		}
		foreach (Branch outBranch in outBranches)
		{
			if ((bool)outBranch.track && outBranch.EqualsFields(branch))
			{
				return inBranch;
			}
		}
		Debug.LogError(string.Concat("This junction doesn't have a branch with track '", currentTrack, "'"), this);
		return null;
	}

	public List<Branch> GetAllNextPotentialBranches(RailTrack currentTrack, bool first)
	{
		Branch branch = new Branch(currentTrack, first);
		if ((bool)inBranch.track && inBranch.EqualsFields(branch))
		{
			if (outBranches.Count == 0)
			{
				return null;
			}
			return outBranches;
		}
		foreach (Branch outBranch in outBranches)
		{
			if ((bool)outBranch.track && outBranch.EqualsFields(branch))
			{
				return new List<Branch> { inBranch };
			}
		}
		Debug.LogError(string.Concat("This junction doesn't have a branch with track '", currentTrack, "'"), this);
		return null;
	}

	public static Junction CreateJunctionObject(Vector3 position, string name = "X")
	{
		GameObject obj = new GameObject("Junction_" + name);
		obj.transform.position = position;
		obj.isStatic = true;
		return obj.AddComponent<Junction>();
	}
}
