using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TreeGen : Writeable, IHasVector
{
	[Serializable]
	public class TreeNode
	{
		private SVector3 pos;

		public List<TreeNode> Children;

		public float Width;

		public Vector3 Pos
		{
			get
			{
				return pos.ToVector3();
			}
			set
			{
				pos = value;
			}
		}

		public TreeNode(Vector3 pos, float width)
		{
			Pos = pos;
			Width = width;
			Children = new List<TreeNode>();
		}

		public TreeNode()
		{
		}
	}

	public float MinHeight;

	public float MaxHeight;

	public float MinRange;

	public float MaxRange;

	public float MinWidth;

	public float MaxWidth;

	public float LeafMin;

	public float LeafMax;

	public int MaxNodeHeight;

	public int Type;

	public Mesh ProtoMesh;

	public Mesh ProtoMesh2;

	public Material WoodMat;

	public Material LeafMat;

	public float LeafSize = 1f;

	public bool Cached;

	private float currentSize = 1f;

	private bool isInitiated;

	[NonSerialized]
	private TreeNode Root;

	private Dictionary<GameObject, float> Leaves = new Dictionary<GameObject, float>();

	public bool ForceVisible;

	public Vector3 size;

	public MeshFilter TreeMesh;

	public Bounds bounds
	{
		get
		{
			return new Bounds(GetComponent<Renderer>().bounds.center, size);
		}
	}

	private CombineInstance GenerateProtoMesh(Vector3 start, Vector3 stop, float width, float width2, bool first)
	{
		CombineInstance result = new CombineInstance
		{
			mesh = ProtoMesh
		};
		Vector3 vector = stop - start;
		if (stop.y == start.y)
		{
			start -= Vector3.up * width;
			stop -= Vector3.up * width;
		}
		else if (!first)
		{
			Vector3 vector2 = new Vector3(Sign(vector.x) * width2, 0f, Sign(vector.z) * width2);
			start -= Vector3.up * width2 + vector2;
			stop -= vector2;
		}
		vector = stop - start;
		result.transform = Matrix4x4.TRS(Vector3.Lerp(start, stop, 0.5f), Quaternion.LookRotation(vector), new Vector3(width, width, vector.magnitude));
		return result;
	}

	private void GenerateLeaves(Vector3 pos)
	{
		GameObject obj = new GameObject("Leaves");
		obj.AddComponent<MeshFilter>().mesh = ProtoMesh;
		obj.AddComponent<MeshRenderer>().material = LeafMat;
		float num = UnityEngine.Random.Range(LeafMin, LeafMax);
		obj.transform.parent = base.transform;
		obj.transform.localPosition = pos;
		obj.transform.rotation = Quaternion.LookRotation(UnityEngine.Random.onUnitSphere);
		obj.transform.localScale = Vector3.one * num;
	}

	private float Sign(float input)
	{
		if (Mathf.Approximately(input, 0f))
		{
			return 0f;
		}
		return (input > 0f) ? 1 : (-1);
	}

	public void InitNow()
	{
		if (isInitiated)
		{
			return;
		}
		if (Root == null)
		{
			if (Type == 0 || Type == 2)
			{
				Root = GenerateTree(new Vector3(0f, UnityEngine.Random.Range(MinHeight, MaxHeight), 0f), 0, false);
				TreeNode treeNode = new TreeNode(Vector3.zero, MaxWidth);
				treeNode.Children.Add(Root);
				Root = treeNode;
			}
			else
			{
				Root = GenerateTree2();
			}
		}
		if (TreeMesh.sharedMesh == null)
		{
			if (Type == 0 || Type == 2)
			{
				GenerateTreeMesh();
				ChangeLeaveSize(currentSize);
			}
			else
			{
				GenerateTreeMesh2();
			}
		}
		GetComponentsInChildren<Renderer>().ToList().ForEach(delegate(Renderer x)
		{
			x.enabled = !Cached;
		});
		GetComponent<Renderer>().enabled = ForceVisible;
		Transform[] componentsInChildren = GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			if (!(transform.gameObject == base.gameObject))
			{
				float value = UnityEngine.Random.Range(LeafMin, LeafMax);
				Leaves.Add(transform.gameObject, value);
			}
		}
		isInitiated = true;
	}

	public IEnumerable<MeshFilter> GetAllLeaves()
	{
		MeshFilter[] componentsInChildren = GetComponentsInChildren<MeshFilter>();
		foreach (MeshFilter meshFilter in componentsInChildren)
		{
			if (!(meshFilter.gameObject == base.gameObject))
			{
				yield return meshFilter;
			}
		}
	}

	private void Start()
	{
		InitWritable();
		InitNow();
	}

	public void ChangeLeaveSize(float val)
	{
		foreach (KeyValuePair<GameObject, float> leaf in Leaves)
		{
			leaf.Key.transform.localScale = Vector3.one * leaf.Value * val;
		}
	}

	private void GenerateTreeMesh()
	{
		List<CombineInstance> list = new List<CombineInstance>();
		subTreeMesh(Root, Root.Children[0], list, 0f);
		Mesh mesh = new Mesh();
		mesh.CombineMeshes(list.ToArray());
		TreeMesh.sharedMesh = mesh;
		size = TreeMesh.sharedMesh.bounds.size;
	}

	private void GenerateTreeMesh2()
	{
		float width = Root.Width;
		CombineInstance combineInstance = new CombineInstance
		{
			mesh = ProtoMesh,
			transform = Matrix4x4.TRS(Vector3.up * width / 2f, Quaternion.identity, new Vector3(0.3f, width, 0.3f))
		};
		Mesh mesh = new Mesh();
		mesh.CombineMeshes(new CombineInstance[1] { combineInstance });
		TreeMesh.sharedMesh = mesh;
		TreeNode treeNode = Root;
		float num = 0f;
		while (treeNode.Children.Count > 0)
		{
			TreeNode treeNode2 = treeNode.Children[0];
			GameObject obj = new GameObject("Leaves");
			obj.AddComponent<MeshFilter>().mesh = ProtoMesh2;
			obj.AddComponent<MeshRenderer>().material = LeafMat;
			obj.transform.parent = base.transform;
			obj.transform.localPosition = new Vector3(0f, treeNode2.Pos.y, 0f);
			obj.transform.rotation = Quaternion.Euler(0f, treeNode2.Pos.x, 0f);
			obj.transform.localScale = Vector3.one * treeNode2.Pos.z;
			num = Mathf.Max(treeNode2.Pos.z, num);
			treeNode = treeNode2;
		}
		size = new Vector3(num + 0.4f, TreeMesh.sharedMesh.bounds.size.y, num + 0.4f);
	}

	private void subTreeMesh(TreeNode parent, TreeNode current, List<CombineInstance> instances, float width, bool first = true)
	{
		instances.Add(GenerateProtoMesh(parent.Pos, current.Pos, parent.Width, width, first));
		foreach (TreeNode child in current.Children)
		{
			subTreeMesh(current, child, instances, parent.Width, false);
		}
		if (current.Children.Count == 0 && Type == 0)
		{
			GenerateLeaves(current.Pos);
		}
	}

	private void Update()
	{
		if (currentSize != LeafSize)
		{
			currentSize = Mathf.Lerp(currentSize, LeafSize, 0.1f);
			if (Mathf.Approximately(currentSize, LeafSize))
			{
				currentSize = LeafSize;
			}
			ChangeLeaveSize(currentSize);
		}
	}

	private TreeNode GenerateTree2()
	{
		float num = UnityEngine.Random.Range(MinHeight, MaxHeight);
		float num2 = num - UnityEngine.Random.Range(MinRange, MaxRange);
		TreeNode treeNode = new TreeNode(Vector3.zero, num);
		TreeNode treeNode2 = treeNode;
		float num3 = num2 / (float)MaxNodeHeight;
		float num4 = (LeafMax - LeafMin) / (float)MaxNodeHeight;
		for (int i = 0; i < MaxNodeHeight; i++)
		{
			TreeNode treeNode3 = new TreeNode(new Vector3(UnityEngine.Random.Range(0f, 360f), num - (float)i * num3, LeafMin + (float)i * num4), 0f);
			treeNode2.Children.Add(treeNode3);
			treeNode2 = treeNode3;
		}
		return treeNode;
	}

	private TreeNode GenerateTree(Vector3 pos, int level, bool OnlyUp, bool first = true)
	{
		float num = 1f - (float)Mathf.Min(level + 1, MaxNodeHeight + 1) / (float)(MaxNodeHeight + 2);
		float width = MinWidth + num * (MaxWidth - MinWidth);
		TreeNode treeNode = new TreeNode(pos, width);
		if (level < MaxNodeHeight && !OnlyUp)
		{
			if (first || UnityEngine.Random.Range(0, 4) != 0)
			{
				TreeNode item = GenerateTree(pos + new Vector3(UnityEngine.Random.Range(MinRange, MaxRange) * num, 0f, 0f), level + UnityEngine.Random.Range(1, MaxNodeHeight - level + 1), true, false);
				treeNode.Children.Add(item);
			}
			if (first || UnityEngine.Random.Range(0, 4) != 0)
			{
				TreeNode item2 = GenerateTree(pos - new Vector3(UnityEngine.Random.Range(MinRange, MaxRange) * num, 0f, 0f), level + UnityEngine.Random.Range(1, MaxNodeHeight - level + 1), true, false);
				treeNode.Children.Add(item2);
			}
			if (first || UnityEngine.Random.Range(0, 4) != 0)
			{
				TreeNode item3 = GenerateTree(pos + new Vector3(0f, 0f, UnityEngine.Random.Range(MinRange, MaxRange) * num), level + UnityEngine.Random.Range(1, MaxNodeHeight - level + 1), true, false);
				treeNode.Children.Add(item3);
			}
			if (first || UnityEngine.Random.Range(0, 4) != 0)
			{
				TreeNode item4 = GenerateTree(pos - new Vector3(0f, 0f, UnityEngine.Random.Range(MinRange, MaxRange) * num), level + UnityEngine.Random.Range(1, MaxNodeHeight - level + 1), true, false);
				treeNode.Children.Add(item4);
			}
		}
		if (OnlyUp || (level < MaxNodeHeight && UnityEngine.Random.Range(0, 2) == 0))
		{
			TreeNode item5 = GenerateTree(pos + new Vector3(0f, UnityEngine.Random.Range(MinHeight, MaxHeight) * num, 0f), level + UnityEngine.Random.Range(1, MaxNodeHeight - level + 1), false, false);
			treeNode.Children.Add(item5);
		}
		return treeNode;
	}

	protected override void SerializeMe(WriteDictionary dictionary, GameReader.NewLoadMode mode, LoadType networkMode, bool checkDIDs)
	{
		dictionary["Root"] = Root;
		dictionary["Position"] = (SVector3)base.transform.position;
		dictionary["Rotation"] = (SVector3)base.transform.rotation;
		dictionary["LeafSize"] = LeafSize;
		dictionary["Type"] = Type;
	}

	protected override object DeserializeMe(WriteDictionary dictionary, bool loading, LoadType networkMode)
	{
		Root = (TreeNode)dictionary["Root"];
		base.transform.SetPositionAndRotation((SVector3)dictionary["Position"], (SVector3)dictionary["Rotation"]);
		LeafSize = (float)dictionary["LeafSize"];
		currentSize = LeafSize;
		Type = dictionary.Get("Type", 0);
		return this;
	}

	public override string WriteName()
	{
		return "Tree";
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawCube(bounds.center, bounds.size);
	}

	public Vector2 GetPos()
	{
		return base.transform.position.FlattenVector3();
	}
}
