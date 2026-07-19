using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace UnityFBXExporter
{
	public class FBXExporter
	{
		public static string VersionInformation => "Model created by Kenney (www.kenney.nl)";

		public static bool ExportGameObjToFBX(GameObject gameObj, string newPath, bool copyMaterials = false, bool copyTextures = false, bool combineMesh = false)
		{
			string value = MeshToString(gameObj, newPath, copyMaterials, copyTextures, combineMesh);
			StreamWriter streamWriter = new StreamWriter(newPath);
			streamWriter.Write(value);
			streamWriter.Close();
			return true;
		}

		public static long GetRandomFBXId()
		{
			return BitConverter.ToInt64(Guid.NewGuid().ToByteArray(), 0);
		}

		public static string MeshToString(GameObject gameObj, string newPath, bool copyMaterials = false, bool copyTextures = false, bool combineMesh = false)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder objects = new StringBuilder();
			objects.AppendLine("; Object properties");
			objects.AppendLine(";------------------------------------------------------------------");
			objects.AppendLine("");
			objects.AppendLine("Objects:  {");
			StringBuilder connections = new StringBuilder();
			connections.AppendLine("; Object connections");
			connections.AppendLine(";------------------------------------------------------------------");
			connections.AppendLine("");
			connections.AppendLine("Connections:  {");
			connections.AppendLine("\t");
			Material[] materials = new Material[0];
			string matObjects = "";
			string connections2 = "";
			FBXUnityMaterialGetter.GetAllMaterialsToString(gameObj, newPath, copyMaterials, copyTextures, out materials, out matObjects, out connections2);
			FBXUnityMeshGetter.GetMeshToString(gameObj, materials, ref objects, ref connections, null, 0L);
			objects.Append(matObjects);
			connections.Append(connections2);
			objects.AppendLine("}");
			connections.AppendLine("}");
			stringBuilder.AppendLine("; FBX 7.3.0 project file");
			stringBuilder.AppendLine("; Copyright (C) 1997-2010 Autodesk Inc. and/or its licensors.");
			stringBuilder.AppendLine("; All rights reserved.");
			stringBuilder.AppendLine("; ----------------------------------------------------");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("FBXHeaderExtension:  {");
			stringBuilder.AppendLine("\tFBXHeaderVersion: 1003");
			stringBuilder.AppendLine("\tFBXVersion: 7300");
			DateTime now = DateTime.Now;
			stringBuilder.AppendLine("\tCreationTimeStamp:  {");
			stringBuilder.AppendLine("\t\tVersion: 1000");
			stringBuilder.AppendLine("\t\tYear: " + now.Year);
			stringBuilder.AppendLine("\t\tMonth: " + now.Month);
			stringBuilder.AppendLine("\t\tDay: " + now.Day);
			stringBuilder.AppendLine("\t\tHour: " + now.Hour);
			stringBuilder.AppendLine("\t\tMinute: " + now.Minute);
			stringBuilder.AppendLine("\t\tSecond: " + now.Second);
			stringBuilder.AppendLine("\t\tMillisecond: " + now.Millisecond);
			stringBuilder.AppendLine("\t}");
			stringBuilder.AppendLine("\tCreator: \"" + VersionInformation + "\"");
			stringBuilder.AppendLine("\tSceneInfo: \"SceneInfo::GlobalInfo\", \"UserData\" {");
			stringBuilder.AppendLine("\t\tType: \"UserData\"");
			stringBuilder.AppendLine("\t\tVersion: 100");
			stringBuilder.AppendLine("\t\tMetaData:  {");
			stringBuilder.AppendLine("\t\t\tVersion: 100");
			stringBuilder.AppendLine("\t\t\tTitle: \"\"");
			stringBuilder.AppendLine("\t\t\tSubject: \"\"");
			stringBuilder.AppendLine("\t\t\tAuthor: \"\"");
			stringBuilder.AppendLine("\t\t\tKeywords: \"\"");
			stringBuilder.AppendLine("\t\t\tRevision: \"\"");
			stringBuilder.AppendLine("\t\t\tComment: \"\"");
			stringBuilder.AppendLine("\t\t}");
			stringBuilder.AppendLine("\t\tProperties70:  {");
			_ = Application.dataPath + newPath + ".fbx";
			stringBuilder.AppendLine("\t\t\tP: \"DocumentUrl\", \"KString\", \"Url\", \"\", \"" + gameObj.name + ".fbx\"");
			stringBuilder.AppendLine("\t\t\tP: \"SrcDocumentUrl\", \"KString\", \"Url\", \"\", \"" + gameObj.name + ".fbx\"");
			stringBuilder.AppendLine("\t\t\tP: \"Original\", \"Compound\", \"\", \"\"");
			stringBuilder.AppendLine("\t\t\tP: \"Original|ApplicationVendor\", \"KString\", \"\", \"\", \"\"");
			stringBuilder.AppendLine("\t\t\tP: \"Original|ApplicationName\", \"KString\", \"\", \"\", \"\"");
			stringBuilder.AppendLine("\t\t\tP: \"Original|ApplicationVersion\", \"KString\", \"\", \"\", \"\"");
			stringBuilder.AppendLine("\t\t\tP: \"Original|DateTime_GMT\", \"DateTime\", \"\", \"\", \"\"");
			stringBuilder.AppendLine("\t\t\tP: \"Original|FileName\", \"KString\", \"\", \"\", \"\"");
			stringBuilder.AppendLine("\t\t\tP: \"LastSaved\", \"Compound\", \"\", \"\"");
			stringBuilder.AppendLine("\t\t\tP: \"LastSaved|ApplicationVendor\", \"KString\", \"\", \"\", \"\"");
			stringBuilder.AppendLine("\t\t\tP: \"LastSaved|ApplicationName\", \"KString\", \"\", \"\", \"\"");
			stringBuilder.AppendLine("\t\t\tP: \"LastSaved|ApplicationVersion\", \"KString\", \"\", \"\", \"\"");
			stringBuilder.AppendLine("\t\t\tP: \"LastSaved|DateTime_GMT\", \"DateTime\", \"\", \"\", \"\"");
			stringBuilder.AppendLine("\t\t}");
			stringBuilder.AppendLine("\t}");
			stringBuilder.AppendLine("}");
			stringBuilder.AppendLine("GlobalSettings:  {");
			stringBuilder.AppendLine("\tVersion: 1000");
			stringBuilder.AppendLine("\tProperties70:  {");
			stringBuilder.AppendLine("\t\tP: \"UpAxis\", \"int\", \"Integer\", \"\",1");
			stringBuilder.AppendLine("\t\tP: \"UpAxisSign\", \"int\", \"Integer\", \"\",1");
			stringBuilder.AppendLine("\t\tP: \"FrontAxis\", \"int\", \"Integer\", \"\",2");
			stringBuilder.AppendLine("\t\tP: \"FrontAxisSign\", \"int\", \"Integer\", \"\",1");
			stringBuilder.AppendLine("\t\tP: \"CoordAxis\", \"int\", \"Integer\", \"\",0");
			stringBuilder.AppendLine("\t\tP: \"CoordAxisSign\", \"int\", \"Integer\", \"\",1");
			stringBuilder.AppendLine("\t\tP: \"OriginalUpAxis\", \"int\", \"Integer\", \"\",-1");
			stringBuilder.AppendLine("\t\tP: \"OriginalUpAxisSign\", \"int\", \"Integer\", \"\",1");
			stringBuilder.AppendLine("\t\tP: \"UnitScaleFactor\", \"double\", \"Number\", \"\",10");
			stringBuilder.AppendLine("\t\tP: \"OriginalUnitScaleFactor\", \"double\", \"Number\", \"\",10");
			stringBuilder.AppendLine("\t\tP: \"AmbientColor\", \"ColorRGB\", \"Color\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\tP: \"DefaultCamera\", \"KString\", \"\", \"\", \"Producer Perspective\"");
			stringBuilder.AppendLine("\t\tP: \"TimeMode\", \"enum\", \"\", \"\",11");
			stringBuilder.AppendLine("\t\tP: \"TimeSpanStart\", \"KTime\", \"Time\", \"\",0");
			stringBuilder.AppendLine("\t\tP: \"TimeSpanStop\", \"KTime\", \"Time\", \"\",479181389250");
			stringBuilder.AppendLine("\t\tP: \"CustomFrameRate\", \"double\", \"Number\", \"\",-1");
			stringBuilder.AppendLine("\t}");
			stringBuilder.AppendLine("}");
			stringBuilder.AppendLine("; Object definitions");
			stringBuilder.AppendLine(";------------------------------------------------------------------");
			stringBuilder.AppendLine("");
			stringBuilder.AppendLine("Definitions:  {");
			stringBuilder.AppendLine("\tVersion: 100");
			stringBuilder.AppendLine("\tCount: 4");
			stringBuilder.AppendLine("\tObjectType: \"GlobalSettings\" {");
			stringBuilder.AppendLine("\t\tCount: 1");
			stringBuilder.AppendLine("\t}");
			stringBuilder.AppendLine("\tObjectType: \"Model\" {");
			stringBuilder.AppendLine("\t\tCount: 1");
			stringBuilder.AppendLine("\t\tPropertyTemplate: \"FbxNode\" {");
			stringBuilder.AppendLine("\t\t\tProperties70:  {");
			stringBuilder.AppendLine("\t\t\t\tP: \"QuaternionInterpolate\", \"enum\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"RotationOffset\", \"Vector3D\", \"Vector\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"RotationPivot\", \"Vector3D\", \"Vector\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"ScalingOffset\", \"Vector3D\", \"Vector\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"ScalingPivot\", \"Vector3D\", \"Vector\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"TranslationActive\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"TranslationMin\", \"Vector3D\", \"Vector\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"TranslationMax\", \"Vector3D\", \"Vector\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"TranslationMinX\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"TranslationMinY\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"TranslationMinZ\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"TranslationMaxX\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"TranslationMaxY\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"TranslationMaxZ\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"RotationOrder\", \"enum\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"RotationSpaceForLimitOnly\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"RotationStiffnessX\", \"double\", \"Number\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"RotationStiffnessY\", \"double\", \"Number\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"RotationStiffnessZ\", \"double\", \"Number\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"AxisLen\", \"double\", \"Number\", \"\",10");
			stringBuilder.AppendLine("\t\t\t\tP: \"PreRotation\", \"Vector3D\", \"Vector\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"PostRotation\", \"Vector3D\", \"Vector\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"RotationActive\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"RotationMin\", \"Vector3D\", \"Vector\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"RotationMax\", \"Vector3D\", \"Vector\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"RotationMinX\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"RotationMinY\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"RotationMinZ\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"RotationMaxX\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"RotationMaxY\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"RotationMaxZ\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"InheritType\", \"enum\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"ScalingActive\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"ScalingMin\", \"Vector3D\", \"Vector\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"ScalingMax\", \"Vector3D\", \"Vector\", \"\",1,1,1");
			stringBuilder.AppendLine("\t\t\t\tP: \"ScalingMinX\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"ScalingMinY\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"ScalingMinZ\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"ScalingMaxX\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"ScalingMaxY\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"ScalingMaxZ\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"GeometricTranslation\", \"Vector3D\", \"Vector\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"GeometricRotation\", \"Vector3D\", \"Vector\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"GeometricScaling\", \"Vector3D\", \"Vector\", \"\",1,1,1");
			stringBuilder.AppendLine("\t\t\t\tP: \"MinDampRangeX\", \"double\", \"Number\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"MinDampRangeY\", \"double\", \"Number\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"MinDampRangeZ\", \"double\", \"Number\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"MaxDampRangeX\", \"double\", \"Number\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"MaxDampRangeY\", \"double\", \"Number\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"MaxDampRangeZ\", \"double\", \"Number\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"MinDampStrengthX\", \"double\", \"Number\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"MinDampStrengthY\", \"double\", \"Number\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"MinDampStrengthZ\", \"double\", \"Number\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"MaxDampStrengthX\", \"double\", \"Number\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"MaxDampStrengthY\", \"double\", \"Number\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"MaxDampStrengthZ\", \"double\", \"Number\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"PreferedAngleX\", \"double\", \"Number\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"PreferedAngleY\", \"double\", \"Number\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"PreferedAngleZ\", \"double\", \"Number\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"LookAtProperty\", \"object\", \"\", \"\"");
			stringBuilder.AppendLine("\t\t\t\tP: \"UpVectorProperty\", \"object\", \"\", \"\"");
			stringBuilder.AppendLine("\t\t\t\tP: \"Show\", \"bool\", \"\", \"\",1");
			stringBuilder.AppendLine("\t\t\t\tP: \"NegativePercentShapeSupport\", \"bool\", \"\", \"\",1");
			stringBuilder.AppendLine("\t\t\t\tP: \"DefaultAttributeIndex\", \"int\", \"Integer\", \"\",-1");
			stringBuilder.AppendLine("\t\t\t\tP: \"Freeze\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"LODBox\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"Lcl Translation\", \"Lcl Translation\", \"\", \"A\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"Lcl Rotation\", \"Lcl Rotation\", \"\", \"A\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"Lcl Scaling\", \"Lcl Scaling\", \"\", \"A\",1,1,1");
			stringBuilder.AppendLine("\t\t\t\tP: \"Visibility\", \"Visibility\", \"\", \"A\",1");
			stringBuilder.AppendLine("\t\t\t\tP: \"Visibility Inheritance\", \"Visibility Inheritance\", \"\", \"\",1");
			stringBuilder.AppendLine("\t\t\t}");
			stringBuilder.AppendLine("\t\t}");
			stringBuilder.AppendLine("\t}");
			stringBuilder.AppendLine("\tObjectType: \"Geometry\" {");
			stringBuilder.AppendLine("\t\tCount: 1");
			stringBuilder.AppendLine("\t\tPropertyTemplate: \"FbxMesh\" {");
			stringBuilder.AppendLine("\t\t\tProperties70:  {");
			stringBuilder.AppendLine("\t\t\t\tP: \"Color\", \"ColorRGB\", \"Color\", \"\",0.8,0.8,0.8");
			stringBuilder.AppendLine("\t\t\t\tP: \"BBoxMin\", \"Vector3D\", \"Vector\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"BBoxMax\", \"Vector3D\", \"Vector\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"Primary Visibility\", \"bool\", \"\", \"\",1");
			stringBuilder.AppendLine("\t\t\t\tP: \"Casts Shadows\", \"bool\", \"\", \"\",1");
			stringBuilder.AppendLine("\t\t\t\tP: \"Receive Shadows\", \"bool\", \"\", \"\",1");
			stringBuilder.AppendLine("\t\t\t}");
			stringBuilder.AppendLine("\t\t}");
			stringBuilder.AppendLine("\t}");
			stringBuilder.AppendLine("\tObjectType: \"Material\" {");
			stringBuilder.AppendLine("\t\tCount: 1");
			stringBuilder.AppendLine("\t\tPropertyTemplate: \"FbxSurfacePhong\" {");
			stringBuilder.AppendLine("\t\t\tProperties70:  {");
			stringBuilder.AppendLine("\t\t\t\tP: \"ShadingModel\", \"KString\", \"\", \"\", \"Phong\"");
			stringBuilder.AppendLine("\t\t\t\tP: \"MultiLayer\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"EmissiveColor\", \"Color\", \"\", \"A\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"EmissiveFactor\", \"Number\", \"\", \"A\",1");
			stringBuilder.AppendLine("\t\t\t\tP: \"AmbientColor\", \"Color\", \"\", \"A\",0.2,0.2,0.2");
			stringBuilder.AppendLine("\t\t\t\tP: \"AmbientFactor\", \"Number\", \"\", \"A\",1");
			stringBuilder.AppendLine("\t\t\t\tP: \"DiffuseColor\", \"Color\", \"\", \"A\",0.8,0.8,0.8");
			stringBuilder.AppendLine("\t\t\t\tP: \"DiffuseFactor\", \"Number\", \"\", \"A\",1");
			stringBuilder.AppendLine("\t\t\t\tP: \"Bump\", \"Vector3D\", \"Vector\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"NormalMap\", \"Vector3D\", \"Vector\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"BumpFactor\", \"double\", \"Number\", \"\",1");
			stringBuilder.AppendLine("\t\t\t\tP: \"TransparentColor\", \"Color\", \"\", \"A\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"TransparencyFactor\", \"Number\", \"\", \"A\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"DisplacementColor\", \"ColorRGB\", \"Color\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"DisplacementFactor\", \"double\", \"Number\", \"\",1");
			stringBuilder.AppendLine("\t\t\t\tP: \"VectorDisplacementColor\", \"ColorRGB\", \"Color\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"VectorDisplacementFactor\", \"double\", \"Number\", \"\",1");
			stringBuilder.AppendLine("\t\t\t\tP: \"SpecularColor\", \"Color\", \"\", \"A\",0.2,0.2,0.2");
			stringBuilder.AppendLine("\t\t\t\tP: \"SpecularFactor\", \"Number\", \"\", \"A\",1");
			stringBuilder.AppendLine("\t\t\t\tP: \"ShininessExponent\", \"Number\", \"\", \"A\",20");
			stringBuilder.AppendLine("\t\t\t\tP: \"ReflectionColor\", \"Color\", \"\", \"A\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"ReflectionFactor\", \"Number\", \"\", \"A\",1");
			stringBuilder.AppendLine("\t\t\t}");
			stringBuilder.AppendLine("\t\t}");
			stringBuilder.AppendLine("\t}");
			stringBuilder.AppendLine("\tObjectType: \"Texture\" {");
			stringBuilder.AppendLine("\t\tCount: 2");
			stringBuilder.AppendLine("\t\tPropertyTemplate: \"FbxFileTexture\" {");
			stringBuilder.AppendLine("\t\t\tProperties70:  {");
			stringBuilder.AppendLine("\t\t\t\tP: \"TextureTypeUse\", \"enum\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"Texture alpha\", \"Number\", \"\", \"A\",1");
			stringBuilder.AppendLine("\t\t\t\tP: \"CurrentMappingType\", \"enum\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"WrapModeU\", \"enum\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"WrapModeV\", \"enum\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"UVSwap\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"PremultiplyAlpha\", \"bool\", \"\", \"\",1");
			stringBuilder.AppendLine("\t\t\t\tP: \"Translation\", \"Vector\", \"\", \"A\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"Rotation\", \"Vector\", \"\", \"A\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"Scaling\", \"Vector\", \"\", \"A\",1,1,1");
			stringBuilder.AppendLine("\t\t\t\tP: \"TextureRotationPivot\", \"Vector3D\", \"Vector\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"TextureScalingPivot\", \"Vector3D\", \"Vector\", \"\",0,0,0");
			stringBuilder.AppendLine("\t\t\t\tP: \"CurrentTextureBlendMode\", \"enum\", \"\", \"\",1");
			stringBuilder.AppendLine("\t\t\t\tP: \"UVSet\", \"KString\", \"\", \"\", \"default\"");
			stringBuilder.AppendLine("\t\t\t\tP: \"UseMaterial\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t\tP: \"UseMipMap\", \"bool\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\t}");
			stringBuilder.AppendLine("\t\t}");
			stringBuilder.AppendLine("\t}");
			stringBuilder.AppendLine("}");
			stringBuilder.AppendLine("");
			stringBuilder.Append(objects.ToString());
			stringBuilder.Append(connections.ToString());
			return stringBuilder.ToString();
		}

		public static void CopyComplexMaterialsToPath(GameObject gameObj, string path, bool copyTextures, string texturesFolder = "/Textures", string materialsFolder = "/Materials")
		{
		}

		public static bool CopyAndRenameAsset(UnityEngine.Object obj, string newName, string newFolderPath)
		{
			return false;
		}

		private static string GetFileName(string path)
		{
			string text = path.ToString();
			return text.Remove(0, text.LastIndexOf('/') + 1);
		}

		private static Material CopyTexturesAndAssignCopiesToMaterial(Material material, string newPath)
		{
			if (material.shader.name == "Standard" || material.shader.name == "Standard (Specular setup)")
			{
				GetTextureUpdateMaterialWithPath(material, "_MainTex", newPath);
				if (material.shader.name == "Standard")
				{
					GetTextureUpdateMaterialWithPath(material, "_MetallicGlossMap", newPath);
				}
				if (material.shader.name == "Standard (Specular setup)")
				{
					GetTextureUpdateMaterialWithPath(material, "_SpecGlossMap", newPath);
				}
				GetTextureUpdateMaterialWithPath(material, "_BumpMap", newPath);
				GetTextureUpdateMaterialWithPath(material, "_BumpMap", newPath);
				GetTextureUpdateMaterialWithPath(material, "_BumpMap", newPath);
				GetTextureUpdateMaterialWithPath(material, "_BumpMap", newPath);
				GetTextureUpdateMaterialWithPath(material, "_ParallaxMap", newPath);
				GetTextureUpdateMaterialWithPath(material, "_OcclusionMap", newPath);
				GetTextureUpdateMaterialWithPath(material, "_EmissionMap", newPath);
				GetTextureUpdateMaterialWithPath(material, "_DetailMask", newPath);
				GetTextureUpdateMaterialWithPath(material, "_DetailAlbedoMap", newPath);
				GetTextureUpdateMaterialWithPath(material, "_DetailNormalMap", newPath);
			}
			else
			{
				Debug.LogError("WARNING: " + material.name + " is not a physically based shader, may not export to package correctly");
			}
			return material;
		}

		private static void GetTextureUpdateMaterialWithPath(Material material, string textureShaderName, string newPath)
		{
			Texture texture = material.GetTexture(textureShaderName);
			if (texture != null)
			{
				string newName = material.name + textureShaderName;
				Texture texture2 = (Texture)CopyAndRenameAssetReturnObject(texture, newName, newPath);
				if (texture2 != null)
				{
					material.SetTexture(textureShaderName, texture2);
				}
			}
		}

		public static UnityEngine.Object CopyAndRenameAssetReturnObject(UnityEngine.Object obj, string newName, string newFolderPath)
		{
			return null;
		}
	}
}
