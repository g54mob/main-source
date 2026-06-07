using System;
using System.Collections.Generic;
using UnityEngine;

public class SkraperGen : Landmark
{
	[Serializable]
	public struct ScraperAssetPack
	{
		public bool Enabled;

		public bool Small;

		public Vector2 RoofOffset;

		public float FloorInset;

		public Mesh Top;

		public Mesh TopCorner;

		public Mesh BottomCorner;

		public Mesh SideCorner;

		public Mesh Front;

		public Mesh RoofCorner;

		public Mesh RoofSide;

		public Vector2Int TopMap;

		public Vector2Int TopCornerMap;

		public Vector2Int BottomCornerMap;

		public Vector2Int SideCornerMap;

		public Vector2Int FrontMap;

		public Material TopMat;

		public Material TopCornerMat;

		public Material BottomCornerMat;

		public Material SideCornerMat;

		public Material FrontMat;

		public IEnumerable<Material> GetMats()
		{
			yield return TopMat;
			yield return TopCornerMat;
			yield return BottomCornerMat;
			yield return SideCornerMat;
			yield return FrontMat;
		}
	}

	public static bool NeverTransparent = false;

	public Rect Blob;

	[NonSerialized]
	public List<ValueTuple<Rect, float>> Blobs = new List<ValueTuple<Rect, float>>();

	public float RoofTopPrefabOffset;

	public Vector3 BillboardLocation;

	public Vector3 BillboardRotation;

	public List<ScraperAssetPack> AssetPacks = new List<ScraperAssetPack>();

	public int ForceAsset = -1;

	public Mesh Quad;

	public Transform SubObjects;

	public Renderer rend2;

	public Transform Floor;

	public MeshFilter FloorMesh;

	public MeshFilter BrickFloorMesh;

	public List<MeshFilter> ScraperMeshes = new List<MeshFilter>();

	public List<SkraperPrefab> RoofTopPrefabs = new List<SkraperPrefab>();

	public Material MainMaterial;

	public Material RoofMaterial;

	[NonSerialized]
	private Dictionary<Material, List<ValueTuple<Mesh, Matrix4x4, Vector2?, Vector2Int>>> _combiner;

	public int RNDSeed;

	[NonSerialized]
	public float Height;

	private bool _hide;

	private bool _initialized;

	private bool _destroyFloor;

	private static List<SkraperPrefab> _prefabCache = new List<SkraperPrefab>();

	protected override void Start()
	{
		base.Start();
		if (!_initialized)
		{
			Init(Blob, RNDSeed, false);
		}
	}

	public override void CreateBillboard()
	{
		Billboard = UnityEngine.Object.Instantiate(GameSettings.Instance.BillboardPrefab);
		Billboard.transform.SetParent(base.transform);
		Billboard.transform.position = BillboardLocation;
		Billboard.transform.rotation = Quaternion.Euler(BillboardRotation);
	}

	private void BlobAlgo(Rect r, Rect initial, int maxHeight, System.Random rnd)
	{
		if (!r.xMin.Appx(initial.xMin) && !r.xMax.Appx(initial.xMax) && !r.yMin.Appx(initial.yMin) && !r.yMax.Appx(initial.yMax))
		{
			return;
		}
		if (r.width <= 6f || r.height <= 6f || (r.width <= 12f && r.height <= 12f) || (r.width <= 24f && r.height <= 24f && rnd.NextDouble() < 0.25))
		{
			if (r.xMax.Appx(initial.xMax) && r.width >= 8f && rnd.Next(2) == 0)
			{
				r = Rect.MinMaxRect(r.xMin, r.yMin, r.xMax - 1f, r.yMax);
			}
			if (r.xMin.Appx(initial.xMin) && r.width >= 8f && rnd.Next(2) == 0)
			{
				r = Rect.MinMaxRect(r.xMin + 1f, r.yMin, r.xMax, r.yMax);
			}
			if (r.yMax.Appx(initial.yMax) && r.height >= 8f && rnd.Next(2) == 0)
			{
				r = Rect.MinMaxRect(r.xMin, r.yMin, r.xMax, r.yMax - 1f);
			}
			if (r.yMin.Appx(initial.yMin) && r.height >= 8f && rnd.Next(2) == 0)
			{
				r = Rect.MinMaxRect(r.xMin, r.yMin + 1f, r.xMax, r.yMax);
			}
			float num = Mathf.Min(maxHeight, rnd.Range(Mathf.Min(r.height, r.width), Mathf.Max(r.width, r.height) * 2f));
			Blobs.Add(new ValueTuple<Rect, float>(r, Mathf.FloorToInt(num / 2f) * 2));
		}
		else if (r.width > r.height)
		{
			int num2 = rnd.Next((int)r.xMin / 2 + 3, (int)r.xMax / 2 - 2) * 2;
			BlobAlgo(Rect.MinMaxRect(r.xMin, r.yMin, num2 - 1, r.yMax), initial, maxHeight, rnd);
			BlobAlgo(Rect.MinMaxRect(num2, r.yMin, r.xMax, r.yMax), initial, maxHeight, rnd);
		}
		else
		{
			int num3 = rnd.Next((int)r.yMin / 2 + 3, (int)r.yMax / 2 - 2) * 2;
			BlobAlgo(Rect.MinMaxRect(r.xMin, r.yMin, r.xMax, num3 - 1), initial, maxHeight, rnd);
			BlobAlgo(Rect.MinMaxRect(r.xMin, num3, r.xMax, r.yMax), initial, maxHeight, rnd);
		}
	}

	public void Init(Rect r, int random, bool placeTrees)
	{
		RNDSeed = random;
		Blob = r;
		System.Random random2 = new System.Random(random);
		Height = 100f;
		int num = random2.Next(0, 2) * 180;
		float num2 = r.width - 2f;
		float num3 = r.height - 2f;
		Rect rect = new Rect((0f - num2) / 2f, (0f - num3) / 2f, num2, num3);
		Rect rect2 = Blob;
		if (r.height > r.width)
		{
			num += 90;
			rect = new Rect(rect.y, rect.x, rect.height, rect.width);
			rect2 = new Rect(rect2.y, rect2.x, rect2.height, rect2.width);
		}
		Quaternion quaternion = Quaternion.Euler(0f, num, 0f);
		BrickFloorMesh.transform.localScale = new Vector3(rect2.width, 1f, rect2.height);
		BrickFloorMesh.GetComponent<MeshRenderer>().material.mainTextureScale = rect2.size / 8f * 9f;
		_combiner = new Dictionary<Material, List<ValueTuple<Mesh, Matrix4x4, Vector2?, Vector2Int>>>();
		MeshCombiner meshCombiner = new MeshCombiner("SkyscraperFloor", false);
		BlobAlgo(rect, rect, Mathf.FloorToInt(Height), random2);
		for (int i = 0; i < Blobs.Count; i++)
		{
			ValueTuple<Rect, float> valueTuple = Blobs[i];
			bool small = valueTuple.Item1.width < 12f && valueTuple.Item1.height < 12f && valueTuple.Item2 < 12f;
			CreateCube(valueTuple.Item1, valueTuple.Item2, meshCombiner, (ForceAsset >= 0) ? AssetPacks[ForceAsset] : AssetPacks.GetRandomWhere((ScraperAssetPack x) => x.Enabled && x.Small == small, random2), random2);
		}
		FloorMesh.sharedMesh = meshCombiner.CreateMesh();
		MeshCombiner meshCombiner2 = new MeshCombiner("Scraper", true);
		foreach (KeyValuePair<Material, List<ValueTuple<Mesh, Matrix4x4, Vector2?, Vector2Int>>> item in _combiner)
		{
			foreach (var item2 in item.Value)
			{
				meshCombiner2.AddMesh(item2.Item1, item2.Item2, item2.Item3, item2.Item4);
			}
			GameObject obj = new GameObject(item.Key.name);
			obj.transform.SetParent(SubObjects.transform);
			MeshFilter meshFilter = obj.AddComponent<MeshFilter>();
			meshFilter.sharedMesh = meshCombiner2.CreateMesh();
			obj.AddComponent<MeshRenderer>().sharedMaterial = MaterialFixer.Get(item.Key);
			meshCombiner2.Clear("Scraper");
			ScraperMeshes.Add(meshFilter);
		}
		_combiner = null;
		_destroyFloor = true;
		Height = Blobs.MaxSafe((ValueTuple<Rect, float> x) => x.Item2);
		for (int num4 = 0; num4 < Blobs.Count; num4++)
		{
			ValueTuple<Rect, float> valueTuple2 = Blobs[num4];
			Blobs[num4] = new ValueTuple<Rect, float>(Utilities.RectCenterSize(Blob.center + valueTuple2.Item1.center.RotateFlat(quaternion), valueTuple2.Item1.size.RotateFlat(quaternion)).FixNegativeSize(), valueTuple2.Item2);
		}
		base.transform.position = Blob.center.ToVector3(0f);
		base.transform.rotation = quaternion;
		_initialized = true;
	}

	private void InitBillboard(Rect r, float y, Utilities.Direction invalidDir, System.Random rnd)
	{
		Utilities.Direction[] array = new Utilities.Direction[4]
		{
			Utilities.Direction.North,
			Utilities.Direction.South,
			Utilities.Direction.East,
			Utilities.Direction.West
		};
		array.Shuffle(rnd);
		Utilities.Direction self = Utilities.Direction.None;
		for (int i = 0; i < array.Length; i++)
		{
			if (!invalidDir.HasFlag(array[i]))
			{
				self = array[i];
				break;
			}
		}
		BillboardLocation = self.ToCenter(r.Expand(0.01f, 0.01f)).ToVector3(y);
		BillboardRotation = Quaternion.LookRotation(self.ToNormal()).eulerAngles;
	}

	private void PlacePrefabs(Rect ar, List<SkraperPrefab> prefabs, float offset, System.Random rnd, float recurseChance, bool placeTrees, int mainRot)
	{
		if (ar.width <= 1f || ar.height <= 1f)
		{
			return;
		}
		if (recurseChance > 0f && rnd.NextFloat() < 0.25f)
		{
			if (placeTrees)
			{
				GameSettings.Instance.SpawnTreeArea(RotateBounds(ar.Expand(-2f, -2f), mainRot).Move(Blob.center.x, Blob.center.y), null, rnd, 1.5f);
			}
		}
		else
		{
			if (prefabs.Count == 0)
			{
				return;
			}
			int index = rnd.Next(0, prefabs.Count);
			SkraperPrefab skraperPrefab = prefabs[index];
			Rect area = skraperPrefab.Area;
			float num = 0f;
			float num2 = 0f;
			bool flag = rnd.NextDouble() > 0.5;
			bool flag2 = rnd.NextDouble() > 0.5;
			bool flag3 = rnd.NextDouble() > 0.5;
			byte b = 0;
			if (flag2)
			{
				b |= 1;
			}
			if (flag3)
			{
				b |= 2;
			}
			if (area.width > ar.width || area.height > ar.height)
			{
				if (!(area.width < ar.height) || !(area.height < ar.width))
				{
					return;
				}
				flag = b == 0 || b == 3;
			}
			if (area.width > ar.height || area.height > ar.width)
			{
				flag = b == 1 || b == 2;
			}
			int num3 = 0;
			switch (b)
			{
			case 1:
				num3 = 270;
				break;
			case 2:
				num3 = 90;
				break;
			case 3:
				num3 = 180;
				break;
			}
			if (flag)
			{
				num3 -= 90;
				if (num3 < 0)
				{
					num3 = 270;
				}
			}
			area = RotateBounds(area, num3);
			num = ((!flag2) ? (ar.xMax - area.xMax) : (ar.xMin - area.xMin));
			num2 = ((!flag3) ? (ar.yMax - area.yMax) : (ar.yMin - area.yMin));
			prefabs.RemoveAt(index);
			SkraperPrefab skraperPrefab2 = UnityEngine.Object.Instantiate(skraperPrefab);
			skraperPrefab2.transform.position = new Vector3(num, offset, num2);
			skraperPrefab2.transform.rotation = Quaternion.Euler(0f, num3, 0f);
			skraperPrefab2.transform.SetParent(SubObjects);
			Color white = Color.white;
			Color white2 = Color.white;
			Color white3 = Color.white;
			skraperPrefab2.Init(white, white2, white3, rnd);
			if (recurseChance > 0f && rnd.NextFloat() < recurseChance)
			{
				bool fullWidth = rnd.NextDouble() > 0.5;
				PlacePrefabs(GetSubRect(area, ar, flag2, flag3, fullWidth), prefabs, offset, rnd, recurseChance, placeTrees, mainRot);
				PlacePrefabs(GetOtherSubRect(area, ar, flag2, flag3, fullWidth), prefabs, offset, rnd, recurseChance, placeTrees, mainRot);
			}
		}
	}

	private Rect GetSubRect(Rect b, Rect ar, bool xMin, bool yMin, bool fullWidth)
	{
		float x;
		float num;
		float num2;
		float y;
		if (fullWidth)
		{
			x = ar.xMin;
			num = ar.width;
			num2 = ar.height - b.height;
			y = (yMin ? (ar.yMax - num2) : ar.yMin);
		}
		else
		{
			num = ar.width - b.width;
			x = (xMin ? (ar.xMax - num) : ar.xMin);
			y = ar.yMin;
			num2 = ar.height;
		}
		return new Rect(x, y, num, num2);
	}

	private Rect GetOtherSubRect(Rect b, Rect ar, bool xMin, bool yMin, bool fullWidth)
	{
		float num;
		float x;
		float y;
		float num2;
		if (fullWidth)
		{
			num = ar.width - b.width;
			x = (xMin ? (ar.xMax - num) : ar.xMin);
			y = (yMin ? ar.yMin : (ar.yMin + (ar.height - b.height)));
			num2 = b.height;
		}
		else
		{
			x = (xMin ? ar.xMin : (ar.xMin + (ar.width - b.width)));
			num = b.width;
			num2 = ar.height - b.height;
			y = (yMin ? (ar.yMax - num2) : ar.yMin);
		}
		return new Rect(x, y, num, num2);
	}

	private Rect RotateBounds(Rect b, int rot)
	{
		if (rot % 360 == 0)
		{
			return b;
		}
		for (int i = 0; i < rot / 90; i++)
		{
			b = Rect.MinMaxRect(b.yMin, 0f - b.xMax, b.yMax, 0f - b.xMin);
		}
		return b;
	}

	private void CreateSideNew(Vector2 a, Vector2 b, Vector3 center, Vector3 forward, ScraperAssetPack assetPack)
	{
		Vector2 vector = (a - b).Abs() - new Vector2(4f, 4f);
		Quaternion quaternion = Quaternion.LookRotation(forward);
		if (vector.x > 0f)
		{
			MakeSkraperObject(assetPack.Front, MainMaterial, assetPack.FrontMap, new Vector2(vector.x / 2f, vector.y / 2f + 1f), center - new Vector3(0f, 1f, 0f), quaternion, new Vector3(vector.x / 2f, vector.y / 2f + 1f, 1f));
		}
		if (vector.y > 0f)
		{
			MakeSkraperObject(assetPack.SideCorner, MainMaterial, assetPack.SideCornerMap, new Vector2(1f, vector.y / 2f), center + quaternion * new Vector3(vector.x / 2f + 1f, 0f, 0f), quaternion, new Vector3(1f, vector.y / 2f, 1f));
		}
		if (vector.x > 0f)
		{
			MakeSkraperObject(assetPack.Top, MainMaterial, assetPack.TopMap, new Vector2(vector.x / 2f, 1f), center + new Vector3(0f, vector.y / 2f + 1f, 0f), quaternion, new Vector3(vector.x / 2f, 1f, 1f));
		}
		MakeSkraperObject(assetPack.TopCorner, MainMaterial, assetPack.TopCornerMap, null, center + new Vector3(0f, vector.y / 2f + 1f, 0f) + quaternion * new Vector3(vector.x / 2f + 1f, 0f, 0f), quaternion, Vector3.one);
		MakeSkraperObject(assetPack.BottomCorner, MainMaterial, assetPack.BottomCornerMap, null, center - new Vector3(0f, vector.y / 2f + 1f, 0f) + quaternion * new Vector3(vector.x / 2f + 1f, 0f, 0f), quaternion, Vector3.one);
		if (assetPack.RoofCorner != null)
		{
			MakeSkraperObject(assetPack.RoofCorner, RoofMaterial, Vector2Int.zero, null, center + new Vector3(0f, vector.y / 2f + 1f, 0f) + quaternion * new Vector3(vector.x / 2f + 1f, 0f, 0f), quaternion, Vector3.one);
		}
		if (assetPack.RoofSide != null)
		{
			MakeSkraperObject(assetPack.RoofSide, RoofMaterial, Vector2Int.zero, new Vector2(1f, vector.x / 2f), center + new Vector3(0f, vector.y / 2f + 1f, 0f), quaternion, new Vector3(vector.x / 2f, 1f, 1f));
		}
	}

	private void MakeSkraperObject(Mesh m, Material mat, Vector2Int atlasPos, Vector2? texScale, Vector3 pos, Quaternion rot, Vector3 scale)
	{
		_combiner.Append(mat, new ValueTuple<Mesh, Matrix4x4, Vector2?, Vector2Int>(m, Matrix4x4.TRS(pos, rot, scale), texScale, atlasPos));
	}

	private void CreateCube(Rect ar, float height, MeshCombiner floorCombiner, ScraperAssetPack assetPack, System.Random rnd)
	{
		CreateSideNew(new Vector2(ar.xMin, 0f), new Vector2(ar.xMax, height), new Vector3(ar.center.x, height / 2f, ar.yMin + 1f), new Vector3(0f, 0f, -1f), assetPack);
		CreateSideNew(new Vector2(ar.xMin, 0f), new Vector2(ar.xMax, height), new Vector3(ar.center.x, height / 2f, ar.yMax - 1f), new Vector3(0f, 0f, 1f), assetPack);
		CreateSideNew(new Vector2(ar.yMin, 0f), new Vector2(ar.yMax, height), new Vector3(ar.xMin + 1f, height / 2f, ar.center.y), new Vector3(-1f, 0f, 0f), assetPack);
		CreateSideNew(new Vector2(ar.yMin, 0f), new Vector2(ar.yMax, height), new Vector3(ar.xMax - 1f, height / 2f, ar.center.y), new Vector3(1f, 0f, 0f), assetPack);
		MakeSkraperObject(Quad, RoofMaterial, Vector2Int.zero, (ar.size + Vector2.one * assetPack.RoofOffset.x) * 0.5f, new Vector3(ar.center.x, height + assetPack.RoofOffset.y, ar.center.y), Quaternion.Euler(90f, 0f, 0f), new Vector3(ar.width + assetPack.RoofOffset.x, ar.height + assetPack.RoofOffset.x, 1f));
		if (floorCombiner != null)
		{
			Rect rect = ar.Expand(0f - assetPack.FloorInset, 0f - assetPack.FloorInset);
			floorCombiner.MakeFace(new Vector3(rect.xMin, 0f, rect.yMin), new Vector3(rect.xMin, 0f, rect.yMax), new Vector3(rect.xMax, 0f, rect.yMax), new Vector3(rect.xMax, 0f, rect.yMin), Vector3.up, Color.black);
		}
	}

	protected override void OnDestroy()
	{
		if (_initialized && _destroyFloor)
		{
			UnityEngine.Object.Destroy(FloorMesh.sharedMesh);
		}
		for (int i = 0; i < ScraperMeshes.Count; i++)
		{
			UnityEngine.Object.Destroy(ScraperMeshes[i].sharedMesh);
		}
		ScraperMeshes.Clear();
		base.OnDestroy();
	}

	private void CreateRoof(SkraperPrefab piece, Vector3 pos, Vector3 scale, Quaternion r, Color rColor, Color gColor, Color bColor, System.Random rnd)
	{
		SkraperPrefab skraperPrefab = UnityEngine.Object.Instantiate(piece);
		skraperPrefab.transform.position = pos;
		skraperPrefab.transform.localScale = scale;
		skraperPrefab.transform.rotation = r;
		skraperPrefab.transform.SetParent(SubObjects);
		skraperPrefab.Init(rColor, gColor, bColor, rnd);
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		bool flag = GameSettings.Instance.ActiveFloor < 0;
		if (_hide ^ flag)
		{
			_hide = flag;
			if (_hide)
			{
				rend2.enabled = false;
				SubObjects.gameObject.SetActive(false);
			}
			else
			{
				rend2.enabled = true;
				SubObjects.gameObject.SetActive(true);
			}
		}
	}

	protected override void SerializeMe(WriteDictionary dictionary, GameReader.NewLoadMode mode, LoadType networkMode, bool checkDIDs)
	{
		base.SerializeMe(dictionary, mode, networkMode, checkDIDs);
		dictionary["x"] = Blob.x;
		dictionary["y"] = Blob.y;
		dictionary["w"] = Blob.width;
		dictionary["h"] = Blob.height;
		dictionary["RNDSeed"] = RNDSeed;
	}

	protected override object DeserializeMe(WriteDictionary d, bool loading, LoadType networkMode)
	{
		Rect r = new Rect(d.Get<float>("x"), d.Get<float>("y"), d.Get<float>("w"), d.Get<float>("h"));
		if (d.Contains("RNDSeed"))
		{
			Init(r, d.Get<int>("RNDSeed"), false);
		}
		else
		{
			int random = LegacyToRandom(d.Get<int>("BandH"), d.Get<int>("BandX"), d.Get<int>("BandY"), d.Get<bool>("north"), d.Get<bool>("west"));
			Init(r, random, false);
		}
		base.DeserializeMe(d, loading, networkMode);
		return this;
	}

	public override string WriteName()
	{
		return "SkyScraper";
	}

	public override Rect GetArea()
	{
		return Blob;
	}

	public override Vector2[] GetNavMesh()
	{
		return new Vector2[4]
		{
			new Vector2(Blob.xMin + 1f, Blob.yMin + 1f),
			new Vector2(Blob.xMax - 1f, Blob.yMin + 1f),
			new Vector2(Blob.xMax - 1f, Blob.yMax - 1f),
			new Vector2(Blob.xMin + 1f, Blob.yMax - 1f)
		};
	}

	public override Vector2 Center()
	{
		return Blob.center;
	}

	public override MeshFilter GetGrassMesh()
	{
		return BrickFloorMesh;
	}

	public override float GetHeight()
	{
		return Height;
	}

	public override bool AreaIsNavMesh()
	{
		return true;
	}

	public int LegacyToRandom(int bandH, int bandX, int bandY, bool topHouseNorth, bool topHouseWest)
	{
		return ((((1116852057 * -1521134295 + topHouseNorth.GetHashCode()) * -1521134295 + topHouseWest.GetHashCode()) * -1521134295 + bandH.GetHashCode()) * -1521134295 + bandX.GetHashCode()) * -1521134295 + bandY.GetHashCode();
	}

	public void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		foreach (var blob in Blobs)
		{
			Rect item = blob.Item1;
			Vector3 center = item.center.ToVector3(blob.Item2 / 2f);
			item = blob.Item1;
			Gizmos.DrawWireCube(center, item.size.ToVector3(blob.Item2));
		}
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(Blob.center.ToVector3(Height / 2f), Blob.size.ToVector3(Height));
	}
}
