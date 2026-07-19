using System.Collections.Generic;
using System.IO;
using Collada141;
using UnityEngine;

public class ExportToCollada
{
	private COLLADA collada;

	private asset ass;

	private library_geometries libraryGeometries;

	private library_visual_scenes visualScenes;

	private visual_scene visualScene;

	private List<node> nodes;

	private List<geometry> geometries;

	private library_materials libraryMaterials;

	private library_images libraryImages;

	private List<image> images;

	private List<material> materials;

	private library_effects libraryEffects;

	private List<effect> effects;

	private int idCounter;

	private string materialId;

	public int maxTextureSize = 512;

	private Dictionary<Mesh, string> meshLookup;

	private string defaultMaterialName = "DefaultMaterial";

	private string workingPath;

	private Dictionary<Material, string> materialCache;

	private Dictionary<Texture, Dictionary<Color32, string>> textureCache;

	private string CreateId()
	{
		return "ID" + idCounter++;
	}

	public ExportToCollada(string workingPath)
	{
		this.workingPath = workingPath;
		collada = new COLLADA();
		geometries = new List<geometry>();
		nodes = new List<node>();
		meshLookup = new Dictionary<Mesh, string>();
		ass = new asset();
		ass.up_axis = UpAxisType.Y_UP;
		ass.unit = new assetUnit();
		ass.unit.meter = 1.0;
		ass.unit.name = "meter";
		libraryGeometries = new library_geometries();
		libraryEffects = new library_effects();
		effects = new List<effect>();
		effects.Add(new effect());
		string text = CreateId();
		effects[0].id = text;
		effects[0].Items = new effectFx_profile_abstractProfile_COMMON[1]
		{
			new effectFx_profile_abstractProfile_COMMON()
		};
		effects[0].Items[0].technique = new effectFx_profile_abstractProfile_COMMONTechnique();
		effects[0].Items[0].technique.sid = "COMMON";
		effectFx_profile_abstractProfile_COMMONTechniquePhong effectFx_profile_abstractProfile_COMMONTechniquePhong2 = new effectFx_profile_abstractProfile_COMMONTechniquePhong();
		effects[0].Items[0].technique.Item = effectFx_profile_abstractProfile_COMMONTechniquePhong2;
		SetPhong(effectFx_profile_abstractProfile_COMMONTechniquePhong2, new Vector4(0.5f, 0.5f, 0.5f, 1f));
		libraryMaterials = new library_materials();
		materials = new List<material>();
		materials.Add(new material());
		materialId = CreateId();
		materials[0].id = materialId;
		materials[0].name = defaultMaterialName;
		materials[0].instance_effect = new instance_effect();
		materials[0].instance_effect.url = "#" + text;
		visualScenes = new library_visual_scenes();
		visualScene = new visual_scene();
		visualScenes.visual_scene = new visual_scene[1] { visualScene };
		string text2 = CreateId();
		visualScenes.visual_scene[0].id = text2;
		libraryImages = new library_images();
		images = new List<image>();
		Build();
		collada.scene = new COLLADAScene();
		collada.scene.instance_visual_scene = new InstanceWithExtra();
		collada.scene.instance_visual_scene.url = "#" + text2;
	}

	private static void SetPhong(effectFx_profile_abstractProfile_COMMONTechniquePhong phong, Vector4 diffuse)
	{
		phong.diffuse = new common_color_or_texture_type();
		common_color_or_texture_typeColor common_color_or_texture_typeColor2 = new common_color_or_texture_typeColor();
		common_color_or_texture_typeColor2.sid = "diffuse";
		phong.diffuse.Item = common_color_or_texture_typeColor2;
		common_color_or_texture_typeColor2.Values = new double[4] { diffuse.x, diffuse.y, diffuse.z, diffuse.w };
		phong.emission = new common_color_or_texture_type();
		common_color_or_texture_typeColor common_color_or_texture_typeColor3 = new common_color_or_texture_typeColor();
		common_color_or_texture_typeColor3.sid = "emission";
		common_color_or_texture_typeColor3.Values = new double[4] { 0.0, 0.0, 0.0, 1.0 };
		phong.emission.Item = common_color_or_texture_typeColor3;
		phong.ambient = new common_color_or_texture_type();
		common_color_or_texture_typeColor common_color_or_texture_typeColor4 = new common_color_or_texture_typeColor();
		common_color_or_texture_typeColor4.sid = "ambient";
		common_color_or_texture_typeColor4.Values = new double[4] { 0.0, 0.0, 0.0, 1.0 };
		phong.ambient.Item = common_color_or_texture_typeColor4;
		phong.specular = new common_color_or_texture_type();
		common_color_or_texture_typeColor common_color_or_texture_typeColor5 = new common_color_or_texture_typeColor();
		common_color_or_texture_typeColor5.sid = "specular";
		common_color_or_texture_typeColor5.Values = new double[4] { 0.5, 0.5, 0.5, 1.0 };
		phong.specular.Item = common_color_or_texture_typeColor5;
		phong.shininess = new common_float_or_param_type();
		common_float_or_param_typeFloat common_float_or_param_typeFloat2 = new common_float_or_param_typeFloat();
		common_float_or_param_typeFloat2.Value = 50.0;
		phong.shininess.Item = common_float_or_param_typeFloat2;
		phong.index_of_refraction = new common_float_or_param_type();
		common_float_or_param_typeFloat common_float_or_param_typeFloat3 = new common_float_or_param_typeFloat();
		common_float_or_param_typeFloat3.Value = 1.0;
		phong.index_of_refraction.Item = common_float_or_param_typeFloat3;
	}

	private static void SetPhongTex(effectFx_profile_abstractProfile_COMMONTechniquePhong phong, string texture)
	{
		phong.diffuse = new common_color_or_texture_type();
		common_color_or_texture_typeTexture common_color_or_texture_typeTexture2 = new common_color_or_texture_typeTexture();
		phong.diffuse.Item = common_color_or_texture_typeTexture2;
		common_color_or_texture_typeTexture2.texture = texture;
		phong.emission = new common_color_or_texture_type();
		common_color_or_texture_typeColor common_color_or_texture_typeColor2 = new common_color_or_texture_typeColor();
		common_color_or_texture_typeColor2.sid = "emission";
		common_color_or_texture_typeColor2.Values = new double[4] { 0.0, 0.0, 0.0, 1.0 };
		phong.emission.Item = common_color_or_texture_typeColor2;
		phong.ambient = new common_color_or_texture_type();
		common_color_or_texture_typeColor common_color_or_texture_typeColor3 = new common_color_or_texture_typeColor();
		common_color_or_texture_typeColor3.sid = "ambient";
		common_color_or_texture_typeColor3.Values = new double[4] { 0.0, 0.0, 0.0, 1.0 };
		phong.ambient.Item = common_color_or_texture_typeColor3;
		phong.specular = new common_color_or_texture_type();
		common_color_or_texture_typeColor common_color_or_texture_typeColor4 = new common_color_or_texture_typeColor();
		common_color_or_texture_typeColor4.sid = "specular";
		common_color_or_texture_typeColor4.Values = new double[4] { 0.5, 0.5, 0.5, 1.0 };
		phong.specular.Item = common_color_or_texture_typeColor4;
		phong.shininess = new common_float_or_param_type();
		common_float_or_param_typeFloat common_float_or_param_typeFloat2 = new common_float_or_param_typeFloat();
		common_float_or_param_typeFloat2.Value = 50.0;
		phong.shininess.Item = common_float_or_param_typeFloat2;
		phong.index_of_refraction = new common_float_or_param_type();
		common_float_or_param_typeFloat common_float_or_param_typeFloat3 = new common_float_or_param_typeFloat();
		common_float_or_param_typeFloat3.Value = 1.0;
		phong.index_of_refraction.Item = common_float_or_param_typeFloat3;
	}

	private static double[] ToDoubleArray(Vector3[] a)
	{
		double[] array = new double[a.Length * 3];
		for (int i = 0; i < a.Length; i++)
		{
			array[i * 3] = a[i].x;
			array[i * 3 + 1] = a[i].y;
			array[i * 3 + 2] = a[i].z;
		}
		return array;
	}

	private static double[] ToDoubleArrayFlipped(Vector3[] a)
	{
		double[] array = new double[a.Length * 3];
		for (int i = 0; i < a.Length; i++)
		{
			array[i * 3] = 0f - a[i].x;
			array[i * 3 + 1] = a[i].y;
			array[i * 3 + 2] = a[i].z;
		}
		return array;
	}

	private static double[] ToDoubleArray(Vector2[] a)
	{
		double[] array = new double[a.Length * 2];
		for (int i = 0; i < a.Length; i++)
		{
			array[i * 2] = a[i].x;
			array[i * 2 + 1] = a[i].y;
		}
		return array;
	}

	private string CreateMesh(Mesh mesh)
	{
		string value = "";
		if (meshLookup.TryGetValue(mesh, out value))
		{
			return value;
		}
		geometry geometry2 = new geometry();
		geometries.Add(geometry2);
		value = (geometry2.id = CreateId());
		mesh mesh2 = (mesh)(geometry2.Item = new mesh());
		mesh2.source = new source[3]
		{
			new source(),
			new source(),
			new source()
		};
		mesh2.source[0].id = CreateId();
		float_array float_array2 = new float_array();
		float_array2.id = CreateId();
		float_array2.Values = ToDoubleArray(mesh.vertices);
		float_array2.count = (ulong)float_array2.Values.Length;
		mesh2.source[0].Item = float_array2;
		mesh2.source[0].technique_common = new sourceTechnique_common();
		mesh2.source[0].technique_common.accessor = new accessor();
		mesh2.source[0].technique_common.accessor.count = float_array2.count / 3;
		mesh2.source[0].technique_common.accessor.source = "#" + float_array2.id;
		mesh2.source[0].technique_common.accessor.stride = 3uL;
		mesh2.source[0].technique_common.accessor.param = new param[3]
		{
			new param(),
			new param(),
			new param()
		};
		mesh2.source[0].technique_common.accessor.param[0].name = "X";
		mesh2.source[0].technique_common.accessor.param[0].type = "float";
		mesh2.source[0].technique_common.accessor.param[1].name = "Y";
		mesh2.source[0].technique_common.accessor.param[1].type = "float";
		mesh2.source[0].technique_common.accessor.param[2].name = "Z";
		mesh2.source[0].technique_common.accessor.param[2].type = "float";
		mesh2.source[1].id = CreateId();
		float_array2 = new float_array();
		float_array2.id = CreateId();
		float_array2.Values = ToDoubleArray(mesh.normals);
		float_array2.count = (ulong)float_array2.Values.Length;
		mesh2.source[1].Item = float_array2;
		mesh2.source[1].technique_common = new sourceTechnique_common();
		mesh2.source[1].technique_common.accessor = new accessor();
		mesh2.source[1].technique_common.accessor.count = float_array2.count / 3;
		mesh2.source[1].technique_common.accessor.source = "#" + float_array2.id;
		mesh2.source[1].technique_common.accessor.stride = 3uL;
		mesh2.source[1].technique_common.accessor.param = new param[3]
		{
			new param(),
			new param(),
			new param()
		};
		mesh2.source[1].technique_common.accessor.param[0].name = "X";
		mesh2.source[1].technique_common.accessor.param[0].type = "float";
		mesh2.source[1].technique_common.accessor.param[1].name = "Y";
		mesh2.source[1].technique_common.accessor.param[1].type = "float";
		mesh2.source[1].technique_common.accessor.param[2].name = "Z";
		mesh2.source[1].technique_common.accessor.param[2].type = "float";
		mesh2.source[2].id = CreateId();
		float_array2 = new float_array();
		float_array2.id = CreateId();
		float_array2.Values = ToDoubleArray(mesh.uv);
		float_array2.count = (ulong)float_array2.Values.Length;
		mesh2.source[2].Item = float_array2;
		mesh2.source[2].technique_common = new sourceTechnique_common();
		mesh2.source[2].technique_common.accessor = new accessor();
		mesh2.source[2].technique_common.accessor.count = float_array2.count / 2;
		mesh2.source[2].technique_common.accessor.source = "#" + float_array2.id;
		mesh2.source[2].technique_common.accessor.stride = 2uL;
		mesh2.source[2].technique_common.accessor.param = new param[2]
		{
			new param(),
			new param()
		};
		mesh2.source[2].technique_common.accessor.param[0].name = "X";
		mesh2.source[2].technique_common.accessor.param[0].type = "float";
		mesh2.source[2].technique_common.accessor.param[1].name = "Y";
		mesh2.source[2].technique_common.accessor.param[1].type = "float";
		mesh2.vertices = new vertices();
		mesh2.vertices.id = CreateId();
		mesh2.vertices.input = new InputLocal[3]
		{
			new InputLocal(),
			new InputLocal(),
			new InputLocal()
		};
		mesh2.vertices.input[0].semantic = "POSITION";
		mesh2.vertices.input[0].source = "#" + mesh2.source[0].id;
		mesh2.vertices.input[1].semantic = "NORMAL";
		mesh2.vertices.input[1].source = "#" + mesh2.source[1].id;
		mesh2.vertices.input[2].semantic = "TEXCOORD";
		mesh2.vertices.input[2].source = "#" + mesh2.source[2].id;
		List<int> list = new List<int>();
		StringWriter stringWriter = new StringWriter();
		for (int i = 0; i < mesh.subMeshCount; i++)
		{
			int[] array = mesh.GetTriangles(i);
			list.AddRange(array);
			for (int j = 0; j < array.Length; j += 3)
			{
				stringWriter.Write("{0} ", array[j]);
				stringWriter.Write("{0} ", array[j + 1]);
				stringWriter.Write("{0} ", array[j + 2]);
			}
		}
		triangles triangles2 = new triangles();
		triangles2.count = (ulong)(list.Count / 3);
		triangles2.material = defaultMaterialName;
		triangles2.input = new InputLocalOffset[1]
		{
			new InputLocalOffset()
		};
		triangles2.input[0].offset = 0uL;
		triangles2.input[0].semantic = "VERTEX";
		triangles2.input[0].source = "#" + mesh2.vertices.id;
		triangles2.p = stringWriter.ToString();
		mesh2.Items = new object[1] { triangles2 };
		meshLookup[mesh] = value;
		return value;
	}

	private string CreateMeshWithSubmeshes(Mesh mesh, List<string> materialNames)
	{
		string value = "";
		if (meshLookup.TryGetValue(mesh, out value))
		{
			return value;
		}
		geometry geometry2 = new geometry();
		geometries.Add(geometry2);
		value = (geometry2.id = CreateId());
		mesh mesh2 = (mesh)(geometry2.Item = new mesh());
		mesh2.source = new source[3]
		{
			new source(),
			new source(),
			new source()
		};
		mesh2.source[0].id = CreateId();
		float_array float_array2 = new float_array();
		float_array2.id = CreateId();
		float_array2.Values = ToDoubleArray(mesh.vertices);
		float_array2.count = (ulong)float_array2.Values.Length;
		mesh2.source[0].Item = float_array2;
		mesh2.source[0].technique_common = new sourceTechnique_common();
		mesh2.source[0].technique_common.accessor = new accessor();
		mesh2.source[0].technique_common.accessor.count = float_array2.count / 3;
		mesh2.source[0].technique_common.accessor.source = "#" + float_array2.id;
		mesh2.source[0].technique_common.accessor.stride = 3uL;
		mesh2.source[0].technique_common.accessor.param = new param[3]
		{
			new param(),
			new param(),
			new param()
		};
		mesh2.source[0].technique_common.accessor.param[0].name = "X";
		mesh2.source[0].technique_common.accessor.param[0].type = "float";
		mesh2.source[0].technique_common.accessor.param[1].name = "Y";
		mesh2.source[0].technique_common.accessor.param[1].type = "float";
		mesh2.source[0].technique_common.accessor.param[2].name = "Z";
		mesh2.source[0].technique_common.accessor.param[2].type = "float";
		mesh2.source[1].id = CreateId();
		float_array2 = new float_array();
		float_array2.id = CreateId();
		float_array2.Values = ToDoubleArray(mesh.normals);
		float_array2.count = (ulong)float_array2.Values.Length;
		mesh2.source[1].Item = float_array2;
		mesh2.source[1].technique_common = new sourceTechnique_common();
		mesh2.source[1].technique_common.accessor = new accessor();
		mesh2.source[1].technique_common.accessor.count = float_array2.count / 3;
		mesh2.source[1].technique_common.accessor.source = "#" + float_array2.id;
		mesh2.source[1].technique_common.accessor.stride = 3uL;
		mesh2.source[1].technique_common.accessor.param = new param[3]
		{
			new param(),
			new param(),
			new param()
		};
		mesh2.source[1].technique_common.accessor.param[0].name = "X";
		mesh2.source[1].technique_common.accessor.param[0].type = "float";
		mesh2.source[1].technique_common.accessor.param[1].name = "Y";
		mesh2.source[1].technique_common.accessor.param[1].type = "float";
		mesh2.source[1].technique_common.accessor.param[2].name = "Z";
		mesh2.source[1].technique_common.accessor.param[2].type = "float";
		mesh2.source[2].id = CreateId();
		float_array2 = new float_array();
		float_array2.id = CreateId();
		float_array2.Values = ToDoubleArray(mesh.uv);
		float_array2.count = (ulong)float_array2.Values.Length;
		mesh2.source[2].Item = float_array2;
		mesh2.source[2].technique_common = new sourceTechnique_common();
		mesh2.source[2].technique_common.accessor = new accessor();
		mesh2.source[2].technique_common.accessor.count = float_array2.count / 2;
		mesh2.source[2].technique_common.accessor.source = "#" + float_array2.id;
		mesh2.source[2].technique_common.accessor.stride = 2uL;
		mesh2.source[2].technique_common.accessor.param = new param[2]
		{
			new param(),
			new param()
		};
		mesh2.source[2].technique_common.accessor.param[0].name = "X";
		mesh2.source[2].technique_common.accessor.param[0].type = "float";
		mesh2.source[2].technique_common.accessor.param[1].name = "Y";
		mesh2.source[2].technique_common.accessor.param[1].type = "float";
		mesh2.vertices = new vertices();
		mesh2.vertices.id = CreateId();
		mesh2.vertices.input = new InputLocal[1]
		{
			new InputLocal()
		};
		mesh2.vertices.input[0].semantic = "POSITION";
		mesh2.vertices.input[0].source = "#" + mesh2.source[0].id;
		List<object> list = new List<object>();
		for (int i = 0; i < mesh.subMeshCount; i++)
		{
			List<int> list2 = new List<int>();
			StringWriter stringWriter = new StringWriter();
			int[] array = mesh.GetTriangles(i);
			list2.AddRange(array);
			for (int j = 0; j < array.Length; j += 3)
			{
				stringWriter.Write("{0} ", array[j]);
				stringWriter.Write("{0} ", array[j]);
				stringWriter.Write("{0} ", array[j]);
				stringWriter.Write("{0} ", array[j + 1]);
				stringWriter.Write("{0} ", array[j + 1]);
				stringWriter.Write("{0} ", array[j + 1]);
				stringWriter.Write("{0} ", array[j + 2]);
				stringWriter.Write("{0} ", array[j + 2]);
				stringWriter.Write("{0} ", array[j + 2]);
			}
			triangles triangles2 = new triangles();
			triangles2.count = (ulong)(list2.Count / 3);
			triangles2.material = materialNames[i];
			triangles2.input = new InputLocalOffset[3]
			{
				new InputLocalOffset(),
				new InputLocalOffset(),
				new InputLocalOffset()
			};
			triangles2.input[0].offset = 0uL;
			triangles2.input[0].semantic = "VERTEX";
			triangles2.input[0].source = "#" + mesh2.vertices.id;
			triangles2.p = stringWriter.ToString();
			triangles2.input[1].offset = 1uL;
			triangles2.input[1].semantic = "NORMAL";
			triangles2.input[1].source = "#" + mesh2.source[1].id;
			triangles2.input[2].offset = 2uL;
			triangles2.input[2].semantic = "TEXCOORD";
			triangles2.input[2].source = "#" + mesh2.source[2].id;
			triangles2.input[2].set = 0uL;
			list.Add(triangles2);
		}
		mesh2.Items = list.ToArray();
		meshLookup[mesh] = value;
		return value;
	}

	private Texture2D MakeReadable(Texture2D texture, Color color, int maxSize)
	{
		int num = texture.width;
		int num2 = texture.height;
		float num3 = Mathf.Max(num, num2);
		if (num3 > (float)maxSize)
		{
			float num4 = (float)maxSize / num3;
			num = (int)((float)num * num4);
			num2 = (int)((float)num2 * num4);
		}
		new Material(Shader.Find("Unlit")).SetColor("_Color", color);
		RenderTexture temporary = RenderTexture.GetTemporary(num, num2, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
		Graphics.Blit(texture, temporary);
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = temporary;
		Texture2D texture2D = new Texture2D(num, num2);
		texture2D.ReadPixels(new Rect(0f, 0f, num, num2), 0, 0);
		texture2D.Apply();
		RenderTexture.active = active;
		RenderTexture.ReleaseTemporary(temporary);
		Color[] pixels = texture2D.GetPixels();
		for (int i = 0; i < pixels.Length; i++)
		{
			pixels[i] *= color;
		}
		texture2D.SetPixels(pixels);
		return texture2D;
	}

	private string Color2String(Color32 c)
	{
		return "_" + c.r + "_" + c.g + "_" + c.b + "_" + c.a;
	}

	private List<string> GetMaterialNames(Material[] materials)
	{
		if (materialCache == null)
		{
			materialCache = new Dictionary<Material, string>();
		}
		if (textureCache == null)
		{
			textureCache = new Dictionary<Texture, Dictionary<Color32, string>>();
		}
		List<string> list = new List<string>();
		for (int i = 0; i < materials.Length; i++)
		{
			Color color = Color.gray;
			if (materials[i].HasProperty("_Color"))
			{
				color = materials[i].color;
			}
			else if (materials[i].HasProperty("_MainColor"))
			{
				color = materials[i].GetColor("_MainColor");
			}
			Color32 key = color;
			string value = "";
			if (materials[i].mainTexture != null)
			{
				if (textureCache.ContainsKey(materials[i].mainTexture))
				{
					textureCache[materials[i].mainTexture].TryGetValue(key, out value);
				}
				else
				{
					textureCache[materials[i].mainTexture] = new Dictionary<Color32, string>();
				}
				if (value == "" && !textureCache[materials[i].mainTexture].TryGetValue(key, out value))
				{
					value = materials[i].name;
					textureCache[materials[i].mainTexture][key] = value;
					Texture2D texture = (Texture2D)materials[i].mainTexture;
					byte[] bytes = MakeReadable(texture, color, maxTextureSize).EncodeToPNG();
					File.WriteAllBytes($"{workingPath}/{value}.png", bytes);
					image image2 = new image();
					image2.id = value;
					image2.name = value;
					image2.Item = value + ".png";
					images.Add(image2);
				}
			}
			if (materialCache.ContainsKey(materials[i]))
			{
				list.Add(materialCache[materials[i]]);
				continue;
			}
			effects.Add(new effect());
			effect effect2 = effects[effects.Count - 1];
			string text = (effect2.id = CreateId());
			if (value != "")
			{
				effect2.newparam = new fx_newparam_common[2]
				{
					new fx_newparam_common(),
					new fx_newparam_common()
				};
				effect2.newparam[0].sid = value + "-surface";
				effect2.newparam[0].surface = new fx_surface_common();
				effect2.newparam[0].surface.type = fx_surface_type_enum.Item2D;
				effect2.newparam[0].surface.init_from = new fx_surface_init_from_common[1]
				{
					new fx_surface_init_from_common()
				};
				effect2.newparam[0].surface.init_from[0].Value = value;
				effect2.newparam[1].sid = value;
				effect2.newparam[1].sampler2D = new fx_sampler2D_common();
				effect2.newparam[1].sampler2D.source = value + "-surface";
			}
			effect2.Items = new effectFx_profile_abstractProfile_COMMON[1]
			{
				new effectFx_profile_abstractProfile_COMMON()
			};
			effect2.Items[0].technique = new effectFx_profile_abstractProfile_COMMONTechnique();
			effect2.Items[0].technique.sid = "COMMON";
			effectFx_profile_abstractProfile_COMMONTechniquePhong effectFx_profile_abstractProfile_COMMONTechniquePhong2 = new effectFx_profile_abstractProfile_COMMONTechniquePhong();
			effect2.Items[0].technique.Item = effectFx_profile_abstractProfile_COMMONTechniquePhong2;
			effectFx_profile_abstractProfile_COMMONTechniquePhong2.diffuse = new common_color_or_texture_type();
			if (value == "")
			{
				SetPhong(effectFx_profile_abstractProfile_COMMONTechniquePhong2, new Vector4(color.r, color.g, color.b, color.a));
			}
			else
			{
				SetPhongTex(effectFx_profile_abstractProfile_COMMONTechniquePhong2, value);
			}
			this.materials.Add(new material());
			material obj = this.materials[this.materials.Count - 1];
			string text3 = (obj.id = "mat_" + CreateId());
			obj.name = materials[i].name;
			obj.instance_effect = new instance_effect();
			obj.instance_effect.url = "#" + text;
			materialCache[materials[i]] = text3;
			list.Add(text3);
		}
		return list;
	}

	public void AddMeshWithMaterials(Mesh mesh, Material[] materials, Matrix4x4 mat_, string name, bool flip = false)
	{
		if (mesh == null)
		{
			Debug.LogWarning("Mesh is null. Object name " + name);
			return;
		}
		List<string> materialNames = GetMaterialNames(materials);
		string text = CreateMeshWithSubmeshes(mesh, materialNames);
		node node2 = new node();
		nodes.Add(node2);
		node2.name = name;
		node2.ItemsElementName = new ItemsChoiceType2[1] { ItemsChoiceType2.matrix };
		node2.id = CreateId();
		matrix matrix2 = new matrix();
		node2.Items = new object[1] { matrix2 };
		matrix2.Values = new double[16];
		for (int i = 0; i < 16; i++)
		{
			matrix2.Values[i] = mat_[i / 4, i % 4];
		}
		node2.instance_geometry = new instance_geometry[1]
		{
			new instance_geometry()
		};
		node2.instance_geometry[0].url = "#" + text;
		node2.instance_geometry[0].bind_material = new bind_material();
		node2.instance_geometry[0].bind_material.technique_common = new instance_material[materialNames.Count];
		for (int j = 0; j < materialNames.Count; j++)
		{
			instance_material instance_material2 = new instance_material();
			instance_material2.symbol = materialNames[j];
			instance_material2.target = "#" + materialNames[j];
			node2.instance_geometry[0].bind_material.technique_common[j] = instance_material2;
		}
	}

	public void AddMesh(Mesh mesh, Matrix4x4 mat_, string name)
	{
		if (mesh == null)
		{
			Debug.LogWarning("Mesh is null. Object name " + name);
			return;
		}
		mat_ = Matrix4x4.Scale(new Vector3(-1f, 1f, 1f)) * mat_;
		string text = CreateMesh(mesh);
		node node2 = new node();
		nodes.Add(node2);
		node2.name = name;
		node2.ItemsElementName = new ItemsChoiceType2[1] { ItemsChoiceType2.matrix };
		node2.id = CreateId();
		matrix matrix2 = new matrix();
		node2.Items = new object[1] { matrix2 };
		matrix2.Values = new double[16];
		for (int i = 0; i < 16; i++)
		{
			matrix2.Values[i] = mat_[i / 4, i % 4];
		}
		node2.instance_geometry = new instance_geometry[1]
		{
			new instance_geometry()
		};
		node2.instance_geometry[0].url = "#" + text;
	}

	private void Build()
	{
		libraryImages.image = images.ToArray();
		libraryEffects.effect = effects.ToArray();
		libraryMaterials.material = materials.ToArray();
		visualScene.node = nodes.ToArray();
		libraryGeometries.geometry = geometries.ToArray();
		collada.version = VersionType.Item141;
		collada.Items = new object[5] { libraryImages, libraryMaterials, libraryEffects, libraryGeometries, visualScenes };
		collada.asset = ass;
	}

	public void Save(string filename)
	{
		Build();
		collada.Save(filename);
	}
}
