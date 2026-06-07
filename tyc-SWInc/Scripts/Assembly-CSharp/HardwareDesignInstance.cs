using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class HardwareDesignInstance : MonoBehaviour
{
	public class HardwareDesignProtoype
	{
		public struct MeshObjetPrototype
		{
			public HardwareDesign.Attachment Obj;

			public byte[] Morphs;

			public int Style;

			public MeshObjetPrototype(HardwareDesign.Attachment obj, byte[] morphs, int style)
			{
				Obj = obj;
				Morphs = morphs;
				Style = style;
			}
		}

		public MeshObjetPrototype Base;

		public Dictionary<HardwareDesign.AttachmentPoint, MeshObjetPrototype> Attachments;

		public HardwareDesignProtoype(MeshObjetPrototype b, Dictionary<HardwareDesign.AttachmentPoint, MeshObjetPrototype> att)
		{
			Base = b;
			Attachments = att;
		}

		private static MeshObjetPrototype GetMeshProto(byte[] stream, ref int offset, HardwareDesign.Attachment o)
		{
			byte style = stream[offset];
			offset++;
			byte b = stream[offset];
			byte[] array = null;
			offset++;
			if (b > 0)
			{
				array = new byte[b];
				for (int i = 0; i < b; i++)
				{
					array[i] = stream[offset + i];
				}
				offset += b;
			}
			return new MeshObjetPrototype(o, array, style);
		}

		public static HardwareDesignProtoype LoadProto(byte[] stream, out Color32 c1, out Color32 c2, out Color32 c3)
		{
			int num = BitConverter.ToInt32(stream, 0);
			string key = Encoding.UTF8.GetString(stream, 4, num);
			num += 4;
			c1 = Color.white;
			c2 = Color.white;
			c3 = Color.white;
			HardwareDesign value;
			if (ObjectDatabase.Instance.HardwareDesigns.TryGetValue(key, out value))
			{
				Dictionary<HardwareDesign.AttachmentPoint, MeshObjetPrototype> dictionary = new Dictionary<HardwareDesign.AttachmentPoint, MeshObjetPrototype>();
				c1 = GetByteColor(stream, ref num);
				c2 = GetByteColor(stream, ref num);
				c3 = GetByteColor(stream, ref num);
				MeshObjetPrototype meshProto = GetMeshProto(stream, ref num, null);
				while (num < stream.Length)
				{
					byte b = stream[num];
					byte b2 = stream[num + 1];
					num += 2;
					if (b < value.Attachments.Count)
					{
						HardwareDesign.AttachmentPoint attachmentPoint = value.Attachments[b];
						if (b2 < attachmentPoint.Attachments.Count)
						{
							HardwareDesign.Attachment o = attachmentPoint.Attachments[b2];
							dictionary[attachmentPoint] = GetMeshProto(stream, ref num, o);
						}
					}
					else
					{
						num++;
						byte b3 = stream[num];
						num += b3 + 1;
					}
				}
				return new HardwareDesignProtoype(meshProto, dictionary);
			}
			return null;
		}
	}

	private static Dictionary<int, float> _globalGroups = new Dictionary<int, float>();

	private static Dictionary<int, HardwareDesign.MeshObject> _meshGroups = new Dictionary<int, HardwareDesign.MeshObject>();

	private static Dictionary<string, int> _count = new Dictionary<string, int>();

	private static Dictionary<int, string> _groups = new Dictionary<int, string>();

	private static Dictionary<int, bool> _groupOnlyEmpty = new Dictionary<int, bool>();

	private static Dictionary<int, int> _styles = new Dictionary<int, int>();

	public HardwareDesign Design;

	public int Layer;

	public int Style;

	[NonSerialized]
	public Dictionary<HardwareDesign.AttachmentPoint, Renderer> Objects = new Dictionary<HardwareDesign.AttachmentPoint, Renderer>();

	[NonSerialized]
	public Dictionary<HardwareDesign.AttachmentPoint, int> Styles = new Dictionary<HardwareDesign.AttachmentPoint, int>();

	[NonSerialized]
	public Dictionary<HardwareDesign.AttachmentPoint, HardwareDesign.MeshObject> MeshObjects = new Dictionary<HardwareDesign.AttachmentPoint, HardwareDesign.MeshObject>();

	[NonSerialized]
	public HardwareDesign.MeshObject BaseObject;

	public Renderer Base;

	public Material Mat;

	public Color[] Colors = new Color[3];

	public void UpdateSubPositions()
	{
		Mesh mesh = new Mesh();
		((SkinnedMeshRenderer)Base).BakeMesh(mesh);
		Vector3[] vertices = mesh.vertices;
		Vector3[] normals = mesh.normals;
		int[] triangles = mesh.triangles;
		UnityEngine.Object.Destroy(mesh);
		for (int i = 0; i < Design.Attachments.Count; i++)
		{
			HardwareDesign.AttachmentPoint attachmentPoint = Design.Attachments[i];
			Renderer value;
			if (Objects.TryGetValue(attachmentPoint, out value))
			{
				HardwareDesign.MeshObject mO = MeshObjects[attachmentPoint];
				HardwareDesign.Attachment attachment = attachmentPoint.Attachments.FirstOrDefault((HardwareDesign.Attachment x) => x.Object.Equals(mO.ID));
				if (attachment != null)
				{
					Vector3 p;
					Vector3 n;
					Vector3 u;
					HardwareDesign.GetPoint(attachmentPoint.Index, attachmentPoint.Type, vertices, normals, triangles, Matrix4x4.identity, attachment.Roll, out p, out n, out u);
					Matrix4x4 matrix4x = Matrix4x4.TRS(p, Quaternion.LookRotation(n, u), Vector3.one);
					value.transform.localPosition = matrix4x.MultiplyPoint(attachment.Offset);
					value.transform.localRotation = matrix4x.rotation * Quaternion.Euler(attachment.Rotation);
					value.transform.localScale = new Vector3((!attachment.FlipX) ? 1 : (-1), (!attachment.FlipY) ? 1 : (-1), (!attachment.FlipZ) ? 1 : (-1));
				}
			}
		}
	}

	private static void AddByteColor(List<byte> stream, Color32 c)
	{
		stream.Add(c.r);
		stream.Add(c.g);
		stream.Add(c.b);
	}

	private static Color32 GetByteColor(byte[] stream, ref int offset)
	{
		Color32 result = new Color32(stream[offset], stream[offset + 1], stream[offset + 2], byte.MaxValue);
		offset += 3;
		return result;
	}

	private static void AddByteRenderer(List<byte> stream, Renderer r, byte style)
	{
		stream.Add(style);
		SkinnedMeshRenderer skinnedMeshRenderer = r as SkinnedMeshRenderer;
		if (skinnedMeshRenderer != null && skinnedMeshRenderer.sharedMesh.blendShapeCount > 0)
		{
			stream.Add((byte)skinnedMeshRenderer.sharedMesh.blendShapeCount);
			for (int i = 0; i < skinnedMeshRenderer.sharedMesh.blendShapeCount; i++)
			{
				stream.Add((byte)Mathf.RoundToInt(skinnedMeshRenderer.GetBlendShapeWeight(i) / 100f * 255f));
			}
		}
		else
		{
			stream.Add(0);
		}
	}

	private void GetByteRenderer(byte[] stream, ref int offset, Renderer r, HardwareDesign.MeshObject o, HardwareDesign.AttachmentPoint ap)
	{
		byte b = stream[offset];
		offset++;
		if (ap != null)
		{
			Styles[ap] = b;
		}
		else
		{
			Style = b;
		}
		if (b > 0)
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			materialPropertyBlock.SetVector("_MainTex_ST", new Vector4(1f, 1f, o.AtlasOffset.x * (float)(int)b, (0f - o.AtlasOffset.y) * (float)(int)b));
			r.SetPropertyBlock(materialPropertyBlock);
		}
		byte b2 = stream[offset];
		offset++;
		if (b2 <= 0)
		{
			return;
		}
		SkinnedMeshRenderer skinnedMeshRenderer = r as SkinnedMeshRenderer;
		if (skinnedMeshRenderer != null)
		{
			int num = Mathf.Min(skinnedMeshRenderer.sharedMesh.blendShapeCount, b2);
			for (int i = 0; i < num; i++)
			{
				skinnedMeshRenderer.SetBlendShapeWeight(i, (float)(int)stream[offset + i] / 255f * 100f);
			}
		}
		offset += b2;
	}

	public byte[] Serialize()
	{
		List<byte> list = new List<byte>();
		byte[] bytes = Encoding.UTF8.GetBytes(Design.ID);
		list.AddRange(BitConverter.GetBytes(bytes.Length));
		list.AddRange(bytes);
		AddByteColor(list, Colors[0]);
		AddByteColor(list, Colors[1]);
		AddByteColor(list, Colors[2]);
		AddByteRenderer(list, Base, (byte)Style);
		foreach (KeyValuePair<HardwareDesign.AttachmentPoint, Renderer> o in Objects)
		{
			list.Add((byte)Design.Attachments.IndexOf(o.Key));
			list.Add((byte)o.Key.Attachments.FindIndex((HardwareDesign.Attachment x) => x.Object.Equals(MeshObjects[o.Key].ID)));
			AddByteRenderer(list, o.Value, (byte)Styles.GetOrDefault(o.Key, 0));
		}
		return list.ToArray();
	}

	public static HardwareDesign GetHardwareDesign(byte[] stream)
	{
		int count = BitConverter.ToInt32(stream, 0);
		string key = Encoding.UTF8.GetString(stream, 4, count);
		return ObjectDatabase.Instance.HardwareDesigns.GetOrNull(key);
	}

	public static HardwareDesignInstance Deserialize(byte[] stream, int layer)
	{
		int num = BitConverter.ToInt32(stream, 0);
		string key = Encoding.UTF8.GetString(stream, 4, num);
		HardwareDesign value;
		if (ObjectDatabase.Instance.HardwareDesigns.TryGetValue(key, out value))
		{
			HardwareDesignInstance hardwareDesignInstance = new GameObject(key).AddComponent<HardwareDesignInstance>();
			hardwareDesignInstance.Layer = layer;
			hardwareDesignInstance.Design = value;
			hardwareDesignInstance.DeserializeObject(stream, 4 + num);
			return hardwareDesignInstance;
		}
		return null;
	}

	public void DeserializeObject(byte[] stream, int offset)
	{
		Mat = new Material(Design.Mat);
		BaseObject = Design.GetObject(Design.BaseMesh);
		bool skinned;
		GameObject gameObject = Design.SpawnObject(BaseObject, out skinned);
		gameObject.layer = Layer;
		gameObject.transform.SetParent(base.transform);
		SetColor(0, GetByteColor(stream, ref offset));
		SetColor(1, GetByteColor(stream, ref offset));
		SetColor(2, GetByteColor(stream, ref offset));
		Base = gameObject.GetComponent<Renderer>();
		Base.sharedMaterial = Mat;
		GetByteRenderer(stream, ref offset, Base, BaseObject, null);
		Vector3[] ps;
		Vector3[] ns;
		int[] ts;
		GetMeshInfo(out ps, out ns, out ts);
		while (offset < stream.Length)
		{
			byte b = stream[offset];
			byte b2 = stream[offset + 1];
			offset += 2;
			if (b < Design.Attachments.Count)
			{
				HardwareDesign.AttachmentPoint attachmentPoint = Design.Attachments[b];
				if (b2 < attachmentPoint.Attachments.Count)
				{
					HardwareDesign.Attachment attachment = attachmentPoint.Attachments[b2];
					HardwareDesign.MeshObject meshObject = Design.GetObject(attachment.Object);
					GameObject obj = Design.SpawnObject(meshObject, out skinned);
					obj.layer = Layer;
					Renderer component = obj.GetComponent<Renderer>();
					Objects[attachmentPoint] = component;
					MeshObjects[attachmentPoint] = meshObject;
					component.sharedMaterial = Mat;
					obj.transform.SetParent(base.transform);
					GetByteRenderer(stream, ref offset, component, meshObject, attachmentPoint);
					Vector3 p;
					Vector3 n;
					Vector3 u;
					HardwareDesign.GetPoint(attachmentPoint.Index, attachmentPoint.Type, ps, ns, ts, Matrix4x4.identity, attachment.Roll, out p, out n, out u);
					Matrix4x4 matrix4x = Matrix4x4.TRS(p, Quaternion.LookRotation(n, u), Vector3.one);
					obj.transform.localPosition = matrix4x.MultiplyPoint(attachment.Offset);
					obj.transform.localRotation = matrix4x.rotation * Quaternion.Euler(attachment.Rotation);
					obj.transform.localScale = new Vector3((!attachment.FlipX) ? 1 : (-1), (!attachment.FlipY) ? 1 : (-1), (!attachment.FlipZ) ? 1 : (-1));
				}
			}
			else
			{
				offset++;
				byte b3 = stream[offset];
				offset += b3 + 1;
			}
		}
	}

	public void ReplaceMesh(HardwareDesign.AttachmentPoint att, HardwareDesign.MeshObject aO)
	{
		if (aO == null)
		{
			Renderer orDefault = Objects.GetOrDefault(att);
			if (orDefault != null)
			{
				UnityEngine.Object.Destroy(orDefault.gameObject);
				Objects.Remove(att);
				MeshObjects.Remove(att);
			}
			return;
		}
		HardwareDesign.Attachment attachment = att.Attachments.FirstOrDefault((HardwareDesign.Attachment x) => x.Object.Equals(aO.ID));
		if (attachment != null)
		{
			Renderer orDefault2 = Objects.GetOrDefault(att);
			if (orDefault2 != null)
			{
				UnityEngine.Object.Destroy(orDefault2.gameObject);
			}
			bool skinned;
			GameObject gameObject = Design.SpawnObject(aO, out skinned);
			gameObject.layer = Layer;
			Renderer component = gameObject.GetComponent<Renderer>();
			Objects[att] = component;
			MeshObjects[att] = aO;
			component.sharedMaterial = Mat;
			if (skinned)
			{
				RandomizeBlend(gameObject, aO, _globalGroups);
			}
			RandomizeAtlas(gameObject, aO, att);
			gameObject.transform.SetParent(base.transform);
			Vector3[] ps;
			Vector3[] ns;
			int[] ts;
			GetMeshInfo(out ps, out ns, out ts);
			Vector3 p;
			Vector3 n;
			Vector3 u;
			HardwareDesign.GetPoint(att.Index, att.Type, ps, ns, ts, Matrix4x4.identity, attachment.Roll, out p, out n, out u);
			Matrix4x4 matrix4x = Matrix4x4.TRS(p, Quaternion.LookRotation(n, u), Vector3.one);
			gameObject.transform.localPosition = matrix4x.MultiplyPoint(attachment.Offset);
			gameObject.transform.localRotation = matrix4x.rotation * Quaternion.Euler(attachment.Rotation);
			gameObject.transform.localScale = new Vector3((!attachment.FlipX) ? 1 : (-1), (!attachment.FlipY) ? 1 : (-1), (!attachment.FlipZ) ? 1 : (-1));
		}
	}

	public void SetColor(int idx, Color c)
	{
		string text = "_Color1";
		switch (idx)
		{
		case 1:
			text = "_Color2";
			break;
		case 2:
			text = "_Color3";
			break;
		}
		Colors[idx] = c;
		Mat.SetColor(text, c);
	}

	public void GetMeshInfo(out Vector3[] ps, out Vector3[] ns, out int[] ts)
	{
		SkinnedMeshRenderer skinnedMeshRenderer = Base as SkinnedMeshRenderer;
		if (skinnedMeshRenderer != null)
		{
			Mesh mesh = new Mesh();
			skinnedMeshRenderer.BakeMesh(mesh);
			ps = mesh.vertices;
			ns = mesh.normals;
			ts = mesh.triangles;
			UnityEngine.Object.Destroy(mesh);
		}
		else
		{
			Mesh sharedMesh = Base.GetComponent<MeshFilter>().sharedMesh;
			ps = sharedMesh.vertices;
			ns = sharedMesh.normals;
			ts = sharedMesh.triangles;
		}
	}

	public static void AddByteRenderer(List<byte> stream, HardwareDesign.MeshObject o, int atlasGroup = -1, HardwareDesignProtoype.MeshObjetPrototype? old = null)
	{
		int value;
		if (old.HasValue)
		{
			value = old.Value.Style;
		}
		else if (atlasGroup < 0 || _styles == null || !_styles.TryGetValue(atlasGroup, out value))
		{
			value = Utilities.RandomRange(0, o.AtlasCount);
			if (atlasGroup >= 0 && _styles != null)
			{
				_styles[atlasGroup] = value;
			}
		}
		stream.Add((byte)value);
		if (o.MorphTargets.Length != 0)
		{
			stream.Add((byte)o.MorphTargets.SumSafe((HardwareDesign.MorphInfo x) => (!x.DoubleMorph) ? 1 : 2));
			int num = 0;
			for (int num2 = 0; num2 < o.MorphTargets.Length; num2++)
			{
				HardwareDesign.MorphInfo morphInfo = o.MorphTargets[num2];
				float value2;
				if (morphInfo.GroupID >= 0 && _globalGroups.TryGetValue(morphInfo.GroupID, out value2))
				{
					SetBlend(value2, stream, morphInfo);
				}
				else if (old.HasValue && Utilities.RandomValue < 0.9f)
				{
					stream.Add(old.Value.Morphs[num]);
					if (morphInfo.DoubleMorph)
					{
						stream.Add(old.Value.Morphs[num + 1]);
					}
					if (morphInfo.GroupID >= 0)
					{
						float num3 = (float)(int)old.Value.Morphs[num] / 255f;
						if (morphInfo.DoubleMorph)
						{
							num3 = ((old.Value.Morphs[num] <= 0) ? (0.5f - (float)(int)old.Value.Morphs[num] / 255f * 0.5f) : (0.5f + num3 * 0.5f));
						}
						_globalGroups[morphInfo.GroupID] = num3;
					}
				}
				else
				{
					float value3 = SetBlend(stream, morphInfo);
					if (morphInfo.GroupID >= 0)
					{
						_globalGroups[morphInfo.GroupID] = value3;
					}
				}
				num++;
				if (morphInfo.DoubleMorph)
				{
					num++;
				}
			}
		}
		else
		{
			stream.Add(0);
		}
	}

	public static byte[] GenerateRandomDesign(Manufacturing manufacturing, SoftwareProduct sequelTo, SoftwareProduct current, SoftwareAddOn addon, IList<FeatureBase> features, Company maker)
	{
		byte[] array = null;
		bool newColors = false;
		bool newAttachments = true;
		if (sequelTo != null)
		{
			if (addon != null)
			{
				if (maker == sequelTo.DevCompany)
				{
					object obj;
					if (current == null)
					{
						obj = null;
					}
					else
					{
						AddOnProduct[] forcedAddons = current.ForcedAddons;
						obj = ((forcedAddons != null) ? forcedAddons.FirstOrDefault((AddOnProduct x) => x.Type == addon) : null);
					}
					AddOnProduct addOnProduct = (AddOnProduct)obj;
					if (addOnProduct == null)
					{
						AddOnProduct[] forcedAddons2 = sequelTo.ForcedAddons;
						addOnProduct = ((forcedAddons2 != null) ? forcedAddons2.FirstOrDefault((AddOnProduct x) => x.Type == addon) : null);
					}
					if (addOnProduct != null)
					{
						array = addOnProduct.HardwareDesign;
					}
				}
			}
			else
			{
				array = sequelTo.HardwareDesign;
			}
		}
		if (addon != null && array == null && current != null && maker != current.DevCompany)
		{
			List<AddOnProduct> orNull = current.Addons.GetOrNull(addon);
			AddOnProduct addOnProduct2 = ((orNull != null) ? orNull.FirstOrDefault((AddOnProduct x) => x.Owner == maker) : null);
			if (addOnProduct2 != null)
			{
				array = addOnProduct2.HardwareDesign;
				newAttachments = false;
			}
			else
			{
				AddOnProduct[] forcedAddons3 = current.ForcedAddons;
				AddOnProduct addOnProduct3 = ((forcedAddons3 != null) ? forcedAddons3.FirstOrDefault((AddOnProduct x) => x.Type == addon) : null);
				if (addOnProduct3 != null)
				{
					array = addOnProduct3.HardwareDesign;
					newColors = true;
					newAttachments = false;
				}
			}
		}
		if (array != null)
		{
			HardwareDesign hardwareDesign = GetHardwareDesign(array);
			if (hardwareDesign != null)
			{
				return GenerateRandom(hardwareDesign, manufacturing.GetDisallowed(hardwareDesign.ID, features), array, newColors, newAttachments);
			}
		}
		HardwareDesign bestDesign = manufacturing.GetBestDesign(SDateTime.Now().Year);
		if (!(bestDesign != null))
		{
			return null;
		}
		return GenerateRandom(bestDesign, manufacturing.GetDisallowed(bestDesign.ID, features));
	}

	public static byte[] GenerateRandom(HardwareDesign design, HashSet<string> disallowed)
	{
		List<byte> list = new List<byte>();
		byte[] bytes = Encoding.UTF8.GetBytes(design.ID);
		list.AddRange(BitConverter.GetBytes(bytes.Length));
		list.AddRange(bytes);
		HardwareDesign.ColorSet random = design.ColorSets.GetRandom();
		if (random != null)
		{
			AddByteColor(list, random.Primaries.GetRandom());
			AddByteColor(list, random.Secondaries.GetRandom());
			AddByteColor(list, random.Tertieries.GetRandom());
		}
		else
		{
			AddByteColor(list, new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));
			AddByteColor(list, new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));
			AddByteColor(list, new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));
		}
		_globalGroups.Clear();
		_count.Clear();
		_groups.Clear();
		_groupOnlyEmpty.Clear();
		_styles.Clear();
		List<HardwareDesign.Attachment> list2 = new List<HardwareDesign.Attachment>();
		_meshGroups.Clear();
		AddByteRenderer(list, design.GetObject(design.BaseMesh));
		foreach (HardwareDesign.AttachmentPoint item in design.Attachments.RandomOrder())
		{
			int num = design.Attachments.IndexOf(item);
			list2.Clear();
			bool flag = false;
			string pre;
			if (item.GroupID >= 0 && _groups.TryGetValue(item.GroupID, out pre))
			{
				if (pre == null)
				{
					continue;
				}
				HardwareDesign.Attachment attachment = item.Attachments.FirstOrDefault((HardwareDesign.Attachment x) => x.Object.Equals(pre));
				if (attachment != null && attachment.UseForGeneration && !disallowed.Contains(attachment.Object))
				{
					list2.Add(attachment);
				}
				flag = true;
			}
			if (!flag && item.CanBeEmpty && Utilities.RandomRange(0, item.Attachments.Count + 1) == 0)
			{
				if (item.GroupID >= 0)
				{
					_groups[item.GroupID] = null;
				}
				continue;
			}
			if (flag && _groupOnlyEmpty.GetOrDefault(item.GroupID, true) && item.ControlOnlyEmpty)
			{
				flag = false;
				list2.Clear();
			}
			if (!flag)
			{
				for (int num2 = 0; num2 < item.Attachments.Count; num2++)
				{
					HardwareDesign.Attachment attachment2 = item.Attachments[num2];
					if (attachment2.UseForGeneration && !disallowed.Contains(attachment2.Object))
					{
						HardwareDesign.MeshObject meshObject = design.GetObject(attachment2.Object);
						HardwareDesign.MeshObject value;
						if (meshObject != null && (meshObject.Max < 0 || _count.GetOrDefault(attachment2.Object, 0) < meshObject.Max) && (meshObject.GroupID < 0 || !_meshGroups.TryGetValue(meshObject.GroupID, out value) || value == meshObject))
						{
							list2.Add(attachment2);
						}
					}
				}
			}
			if (list2.Count > 0)
			{
				HardwareDesign.Attachment random2 = list2.GetRandom();
				HardwareDesign.MeshObject meshObject2 = design.GetObject(random2.Object);
				if (meshObject2.GroupID >= 0)
				{
					_meshGroups[meshObject2.GroupID] = meshObject2;
				}
				if (item.GroupID >= 0)
				{
					_groups[item.GroupID] = random2.Object;
					_groupOnlyEmpty[item.GroupID] = item.ControlOnlyEmpty;
				}
				list.Add((byte)num);
				list.Add((byte)item.Attachments.IndexOf(random2));
				AddByteRenderer(list, meshObject2, random2.GroupID);
				_count.AddUp(random2.Object);
			}
		}
		return list.ToArray();
	}

	public static byte[] GenerateRandom(HardwareDesign design, HashSet<string> disallowed, byte[] prev, bool newColors, bool newAttachments)
	{
		Color32 c;
		Color32 c2;
		Color32 c3;
		HardwareDesignProtoype hardwareDesignProtoype = HardwareDesignProtoype.LoadProto(prev, out c, out c2, out c3);
		List<byte> list = new List<byte>();
		byte[] bytes = Encoding.UTF8.GetBytes(design.ID);
		list.AddRange(BitConverter.GetBytes(bytes.Length));
		list.AddRange(bytes);
		if (newColors)
		{
			HardwareDesign.ColorSet random = design.ColorSets.GetRandom();
			if (random != null)
			{
				AddByteColor(list, random.Primaries.GetRandom());
				AddByteColor(list, random.Secondaries.GetRandom());
				AddByteColor(list, random.Tertieries.GetRandom());
			}
			else
			{
				AddByteColor(list, c);
				AddByteColor(list, c2);
				AddByteColor(list, c3);
			}
		}
		else
		{
			AddByteColor(list, c);
			AddByteColor(list, c2);
			AddByteColor(list, c3);
		}
		_globalGroups.Clear();
		_count.Clear();
		_groups.Clear();
		_groupOnlyEmpty.Clear();
		_styles.Clear();
		List<HardwareDesign.Attachment> list2 = new List<HardwareDesign.Attachment>();
		_meshGroups.Clear();
		AddByteRenderer(list, design.GetObject(design.BaseMesh), -1, hardwareDesignProtoype.Base);
		for (int i = 0; i < design.Attachments.Count; i++)
		{
			list2.Clear();
			bool flag = false;
			bool flag2 = false;
			HardwareDesign.AttachmentPoint attachmentPoint = design.Attachments[i];
			if (!newAttachments && !hardwareDesignProtoype.Attachments.ContainsKey(attachmentPoint))
			{
				continue;
			}
			string pre;
			if (hardwareDesignProtoype.Attachments.ContainsKey(attachmentPoint) && (!newAttachments || Utilities.RandomValue < 0.9f))
			{
				list2.Add(hardwareDesignProtoype.Attachments[attachmentPoint].Obj);
				flag = true;
				flag2 = true;
			}
			else if (attachmentPoint.GroupID >= 0 && _groups.TryGetValue(attachmentPoint.GroupID, out pre))
			{
				if (pre == null)
				{
					continue;
				}
				HardwareDesign.Attachment attachment = attachmentPoint.Attachments.FirstOrDefault((HardwareDesign.Attachment x) => x.Object.Equals(pre));
				if (attachment != null && attachment.UseForGeneration && !disallowed.Contains(attachment.Object))
				{
					list2.Add(attachment);
				}
				flag = true;
			}
			if (!flag && attachmentPoint.CanBeEmpty && Utilities.RandomRange(0, attachmentPoint.Attachments.Count + 1) == 0)
			{
				if (attachmentPoint.GroupID >= 0)
				{
					_groups[attachmentPoint.GroupID] = null;
				}
				continue;
			}
			if (flag && !flag2 && _groupOnlyEmpty.GetOrDefault(attachmentPoint.GroupID, true) && attachmentPoint.ControlOnlyEmpty)
			{
				flag = false;
				list2.Clear();
			}
			if (!flag && !flag2)
			{
				for (int num = 0; num < attachmentPoint.Attachments.Count; num++)
				{
					HardwareDesign.Attachment attachment2 = attachmentPoint.Attachments[num];
					if (attachment2.UseForGeneration && !disallowed.Contains(attachment2.Object))
					{
						HardwareDesign.MeshObject meshObject = design.GetObject(attachment2.Object);
						HardwareDesign.MeshObject value;
						if (meshObject != null && (meshObject.Max < 0 || _count.GetOrDefault(attachment2.Object, 0) < meshObject.Max) && (meshObject.GroupID < 0 || !_meshGroups.TryGetValue(meshObject.GroupID, out value) || value == meshObject))
						{
							list2.Add(attachment2);
						}
					}
				}
			}
			if (list2.Count > 0)
			{
				HardwareDesign.Attachment random2 = list2.GetRandom();
				HardwareDesign.MeshObject meshObject2 = design.GetObject(random2.Object);
				if (meshObject2.GroupID >= 0)
				{
					_meshGroups[meshObject2.GroupID] = meshObject2;
				}
				if (attachmentPoint.GroupID >= 0)
				{
					_groups[attachmentPoint.GroupID] = random2.Object;
					_groupOnlyEmpty[attachmentPoint.GroupID] = attachmentPoint.ControlOnlyEmpty;
				}
				list.Add((byte)i);
				list.Add((byte)attachmentPoint.Attachments.IndexOf(random2));
				AddByteRenderer(list, meshObject2, random2.GroupID, flag2 ? new HardwareDesignProtoype.MeshObjetPrototype?(hardwareDesignProtoype.Attachments[attachmentPoint]) : ((HardwareDesignProtoype.MeshObjetPrototype?)null));
				_count.AddUp(random2.Object);
			}
		}
		return list.ToArray();
	}

	public void Randomize(HashSet<string> disallowed)
	{
		HardwareDesign.ColorSet random = Design.ColorSets.GetRandom();
		if (Design.ColorPrimary)
		{
			SetColor(0, (random != null) ? random.Primaries.GetRandom() : Color.white);
		}
		if (Design.ColorSecondary)
		{
			SetColor(1, (random != null) ? random.Secondaries.GetRandom() : Color.white);
		}
		if (Design.ColorTertiary)
		{
			SetColor(2, (random != null) ? random.Tertieries.GetRandom() : Color.white);
		}
		foreach (KeyValuePair<HardwareDesign.AttachmentPoint, Renderer> @object in Objects)
		{
			UnityEngine.Object.Destroy(@object.Value.gameObject);
		}
		Objects.Clear();
		MeshObjects.Clear();
		_globalGroups.Clear();
		SkinnedMeshRenderer skinnedMeshRenderer = Base as SkinnedMeshRenderer;
		if (skinnedMeshRenderer != null)
		{
			int num = 0;
			for (int i = 0; i < BaseObject.MorphTargets.Length; i++)
			{
				HardwareDesign.MorphInfo morphInfo = BaseObject.MorphTargets[i];
				float value = SetBlend(skinnedMeshRenderer, num, morphInfo);
				num = ((!morphInfo.DoubleMorph) ? (num + 1) : (num + 2));
				int groupID = BaseObject.MorphTargets[i].GroupID;
				if (groupID >= 0)
				{
					_globalGroups[groupID] = value;
				}
			}
		}
		Vector3[] ps;
		Vector3[] ns;
		int[] ts;
		GetMeshInfo(out ps, out ns, out ts);
		RandomizeAtlas(Base, BaseObject, null);
		_count.Clear();
		_groups.Clear();
		_groupOnlyEmpty.Clear();
		_styles.Clear();
		List<HardwareDesign.Attachment> list = new List<HardwareDesign.Attachment>();
		_meshGroups.Clear();
		foreach (HardwareDesign.AttachmentPoint item in Design.Attachments.RandomOrder())
		{
			list.Clear();
			bool flag = false;
			string pre;
			if (item.GroupID >= 0 && _groups.TryGetValue(item.GroupID, out pre))
			{
				if (pre == null)
				{
					continue;
				}
				HardwareDesign.Attachment attachment = item.Attachments.FirstOrDefault((HardwareDesign.Attachment x) => x.Object.Equals(pre));
				if (attachment != null && attachment.UseForGeneration && !disallowed.Contains(attachment.Object))
				{
					list.Add(attachment);
				}
				flag = true;
			}
			if (!flag && item.CanBeEmpty && Utilities.RandomRange(0, item.Attachments.Count + 1) == 0)
			{
				if (item.GroupID >= 0)
				{
					_groups[item.GroupID] = null;
				}
				continue;
			}
			if (flag && _groupOnlyEmpty.GetOrDefault(item.GroupID, true) && item.ControlOnlyEmpty)
			{
				flag = false;
				list.Clear();
			}
			if (!flag)
			{
				for (int num2 = 0; num2 < item.Attachments.Count; num2++)
				{
					HardwareDesign.Attachment attachment2 = item.Attachments[num2];
					if (attachment2.UseForGeneration && !disallowed.Contains(attachment2.Object))
					{
						HardwareDesign.MeshObject meshObject = Design.GetObject(attachment2.Object);
						HardwareDesign.MeshObject value2;
						if (meshObject != null && (meshObject.Max < 0 || _count.GetOrDefault(attachment2.Object, 0) < meshObject.Max) && (meshObject.GroupID < 0 || !_meshGroups.TryGetValue(meshObject.GroupID, out value2) || value2 == meshObject))
						{
							list.Add(attachment2);
						}
					}
				}
			}
			if (list.Count > 0)
			{
				HardwareDesign.Attachment random2 = list.GetRandom();
				HardwareDesign.MeshObject meshObject2 = Design.GetObject(random2.Object);
				if (meshObject2.GroupID >= 0)
				{
					_meshGroups[meshObject2.GroupID] = meshObject2;
				}
				if (item.GroupID >= 0)
				{
					_groups[item.GroupID] = random2.Object;
					_groupOnlyEmpty[item.GroupID] = item.ControlOnlyEmpty;
				}
				_count.AddUp(random2.Object);
				bool skinned;
				GameObject gameObject = Design.SpawnObject(meshObject2, out skinned);
				gameObject.layer = Layer;
				Renderer component = gameObject.GetComponent<Renderer>();
				Objects[item] = component;
				MeshObjects[item] = meshObject2;
				component.sharedMaterial = Mat;
				if (skinned)
				{
					RandomizeBlend(gameObject, meshObject2, _globalGroups);
				}
				RandomizeAtlas(gameObject, meshObject2, item, random2.GroupID, _styles);
				gameObject.transform.SetParent(base.transform);
				Vector3 p;
				Vector3 n;
				Vector3 u;
				HardwareDesign.GetPoint(item.Index, item.Type, ps, ns, ts, Matrix4x4.identity, random2.Roll, out p, out n, out u);
				Matrix4x4 matrix4x = Matrix4x4.TRS(p, Quaternion.LookRotation(n, u), Vector3.one);
				gameObject.transform.localPosition = matrix4x.MultiplyPoint(random2.Offset);
				gameObject.transform.localRotation = matrix4x.rotation * Quaternion.Euler(random2.Rotation);
				gameObject.transform.localScale = new Vector3((!random2.FlipX) ? 1 : (-1), (!random2.FlipY) ? 1 : (-1), (!random2.FlipZ) ? 1 : (-1));
			}
		}
	}

	public void CreateRandom(HashSet<string> disallowed)
	{
		Mat = new Material(Design.Mat);
		BaseObject = Design.GetObject(Design.BaseMesh);
		bool skinned;
		GameObject gameObject = Design.SpawnObject(BaseObject, out skinned);
		gameObject.layer = Layer;
		gameObject.transform.SetParent(base.transform);
		Base = gameObject.GetComponent<Renderer>();
		Base.sharedMaterial = Mat;
		Randomize(disallowed);
	}

	public bool UpdateBlend(float val, HardwareDesign.MeshObject o, SkinnedMeshRenderer skin, int mI, HardwareDesign.MorphInfo morph, bool spread, HashSet<HardwareDesign.AttachmentPoint> ignore)
	{
		if (morph.DoubleMorph)
		{
			if (val > 0.5f)
			{
				skin.SetBlendShapeWeight(mI, 0f);
				skin.SetBlendShapeWeight(mI + 1, (val - 0.5f) * 200f);
			}
			else
			{
				skin.SetBlendShapeWeight(mI, (1f - val * 2f) * 100f);
				skin.SetBlendShapeWeight(mI + 1, 0f);
			}
		}
		else
		{
			skin.SetBlendShapeWeight(mI, val * 100f);
		}
		bool flag = o.ID.Equals(Design.BaseMesh);
		if (spread && morph.GroupID >= 0)
		{
			for (int i = 0; i < Design.Attachments.Count; i++)
			{
				HardwareDesign.AttachmentPoint attachmentPoint = Design.Attachments[i];
				HardwareDesign.MeshObject value;
				if (ignore.Contains(attachmentPoint) || !MeshObjects.TryGetValue(attachmentPoint, out value) || value.MorphTargets == null || value.MorphTargets.Length == 0)
				{
					continue;
				}
				SkinnedMeshRenderer skin2 = Objects[attachmentPoint] as SkinnedMeshRenderer;
				int num = 0;
				for (int j = 0; j < value.MorphTargets.Length; j++)
				{
					HardwareDesign.MorphInfo morphInfo = value.MorphTargets[j];
					if (morphInfo.GroupID == morph.GroupID)
					{
						flag |= UpdateBlend(val, value, skin2, num, morphInfo, false, ignore);
					}
					num = ((!morphInfo.DoubleMorph) ? (num + 1) : (num + 2));
				}
			}
		}
		return flag;
	}

	public static void SetBlend(float val, List<byte> stream, HardwareDesign.MorphInfo info)
	{
		if (info.DoubleMorph)
		{
			if (val > 0.5f)
			{
				val = (val - 0.5f) * 2f;
				stream.Add(0);
				stream.Add((byte)Mathf.RoundToInt(val * 255f));
			}
			else if (val < 0.5f)
			{
				val = 1f - val * 2f;
				stream.Add((byte)Mathf.RoundToInt(val * 255f));
				stream.Add(0);
			}
			else
			{
				stream.Add(0);
				stream.Add(0);
			}
		}
		else if (val > 0f)
		{
			val = val.MapRange(0f, 1f, info.MinValue, 100f, true) / 100f;
			stream.Add((byte)Mathf.RoundToInt(val * 255f));
		}
		else
		{
			stream.Add(0);
		}
	}

	public static void SetBlend(float val, SkinnedMeshRenderer r, int i, HardwareDesign.MorphInfo info)
	{
		if (info.DoubleMorph)
		{
			if (val > 0.5f)
			{
				r.SetBlendShapeWeight(i, 0f);
				val = (val - 0.5f) * 2f;
				i++;
			}
			else
			{
				if (!(val < 0.5f))
				{
					r.SetBlendShapeWeight(i, 0f);
					r.SetBlendShapeWeight(i + 1, 0f);
					return;
				}
				r.SetBlendShapeWeight(i + 1, 0f);
				val = 1f - val * 2f;
			}
		}
		if (val > 0f)
		{
			val = val.MapRange(0f, 1f, info.MinValue, 100f, true);
		}
		r.SetBlendShapeWeight(i, val);
	}

	public static float SetBlend(SkinnedMeshRenderer r, int i, HardwareDesign.MorphInfo info)
	{
		if (info.Chance >= 1f || Utilities.RandomValue < info.Chance)
		{
			float num = (info.Gauss ? Utilities.RandomGaussClamped(info.Mean, info.Deviation) : Utilities.RandomValue);
			SetBlend(num, r, i, info);
			return num;
		}
		r.SetBlendShapeWeight(i, 0f);
		return 0f;
	}

	public static float SetBlend(List<byte> stream, HardwareDesign.MorphInfo info)
	{
		if (info.Chance >= 1f || Utilities.RandomValue < info.Chance)
		{
			float num = (info.Gauss ? Utilities.RandomGaussClamped(info.Mean, info.Deviation) : Utilities.RandomValue);
			SetBlend(num, stream, info);
			return num;
		}
		if (info.DoubleMorph)
		{
			stream.Add(0);
		}
		stream.Add(0);
		return 0f;
	}

	private void RandomizeAtlas(GameObject obj, HardwareDesign.MeshObject mo, HardwareDesign.AttachmentPoint at, int group = -1, Dictionary<int, int> styles = null)
	{
		RandomizeAtlas(obj.GetComponent<Renderer>(), mo, at, group, styles);
	}

	private void RandomizeAtlas(Renderer rend, HardwareDesign.MeshObject mo, HardwareDesign.AttachmentPoint at, int group = -1, Dictionary<int, int> styles = null)
	{
		if (mo.AtlasCount <= 1)
		{
			return;
		}
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		int value;
		if (group < 0 || styles == null || !styles.TryGetValue(group, out value))
		{
			value = Utilities.RandomRange(0, mo.AtlasCount);
			if (group >= 0 && styles != null)
			{
				styles[group] = value;
			}
		}
		if (at == null)
		{
			Style = value;
		}
		else
		{
			Styles[at] = value;
		}
		materialPropertyBlock.SetVector("_MainTex_ST", new Vector4(1f, 1f, mo.AtlasOffset.x * (float)value, (0f - mo.AtlasOffset.y) * (float)value));
		rend.SetPropertyBlock(materialPropertyBlock);
	}

	public void OffsetAtlas(Renderer rend, HardwareDesign.MeshObject mo, HardwareDesign.AttachmentPoint at, int i)
	{
		if (mo.AtlasCount > 1)
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			int num = Style;
			if (at != null)
			{
				num = Styles.GetOrDefault(at, num);
			}
			num += i;
			num = ((num >= 0) ? (num % mo.AtlasCount) : (mo.AtlasCount + num));
			if (at == null)
			{
				Style = num;
			}
			else
			{
				Styles[at] = num;
			}
			materialPropertyBlock.SetVector("_MainTex_ST", new Vector4(1f, 1f, mo.AtlasOffset.x * (float)num, (0f - mo.AtlasOffset.y) * (float)num));
			rend.SetPropertyBlock(materialPropertyBlock);
		}
	}

	private void RandomizeBlend(GameObject obj, HardwareDesign.MeshObject mo, Dictionary<int, float> globalGroups)
	{
		SkinnedMeshRenderer component = obj.GetComponent<SkinnedMeshRenderer>();
		for (int i = 0; i < mo.MorphTargets.Length; i++)
		{
			HardwareDesign.MorphInfo morphInfo = mo.MorphTargets[i];
			int actualMorphIndex = mo.GetActualMorphIndex(i);
			float value;
			if (morphInfo.GroupID >= 0 && globalGroups.TryGetValue(morphInfo.GroupID, out value))
			{
				SetBlend(value, component, actualMorphIndex, morphInfo);
				continue;
			}
			float value2 = SetBlend(component, actualMorphIndex, morphInfo);
			if (morphInfo.GroupID >= 0)
			{
				globalGroups[morphInfo.GroupID] = value2;
			}
		}
	}
}
