using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace TriLib
{
	public static class AssimpInterop
	{
		public delegate IntPtr DataCallback(string pFile, int fileId, ref int fileSize);

		public delegate bool ExistsCallback(string pFile, int fileId);

		public delegate void ProgressCallback(float progress);

		private const string DllPath = "assimp";

		private const int MaxStringLength = 1024;

		private const int MaxInputStringLength = 2048;

		public static readonly bool Is32Bits;

		public static readonly int IntSize;

		[PreserveSig]
		private static extern IntPtr _aiCreatePropertyStore();

		public static IntPtr ai_CreatePropertyStore()
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern void _aiReleasePropertyStore(IntPtr ptrPropertyStore);

		public static void ai_CreateReleasePropertyStore(IntPtr ptrPropertyStore)
		{
		}

		[PreserveSig]
		private static extern IntPtr _aiSetImportPropertyInteger(IntPtr ptrStore, IntPtr name, int value);

		public static IntPtr ai_SetImportPropertyInteger(IntPtr ptrStore, string name, int value)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiSetImportPropertyFloat(IntPtr ptrStore, IntPtr name, float value);

		public static IntPtr ai_SetImportPropertyFloat(IntPtr ptrStore, string name, float value)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiSetImportPropertyString(IntPtr ptrStore, IntPtr name, IntPtr ptrValue);

		public static IntPtr ai_SetImportPropertyString(IntPtr ptrStore, string name, string value)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiSetImportPropertyMatrix(IntPtr ptrStore, IntPtr name, IntPtr ptrValue);

		public static IntPtr ai_SetImportPropertyMatrix(IntPtr ptrStore, string name, Vector3 translation, Vector3 rotation, Vector3 scale)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiImportFileFromMemory(IntPtr ptrBuffer, uint uintLength, uint uintFlags, int fileId, string strHint, DataCallback dataCallback, ExistsCallback existsCallback, ProgressCallback progressCallback);

		public static IntPtr ai_ImportFileFromMemory(byte[] fileBytes, uint uintFlags, string strHint, DataCallback dataCallback, ExistsCallback existsCallback, int fileId, ProgressCallback progressCallback)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiImportFileFromMemoryWithProperties(IntPtr ptrBuffer, uint uintLength, uint uintFlags, int fileId, string strHint, IntPtr ptrProps, DataCallback dataCallback, ExistsCallback existsCallback, ProgressCallback progressCallback);

		public static IntPtr ai_ImportFileFromMemoryWithProperties(byte[] fileBytes, uint uintFlags, string strHint, IntPtr ptrProps, DataCallback dataCallback, ExistsCallback existsCallback, int fileId, ProgressCallback progressCallback)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiImportFile(string filename, uint flags, ProgressCallback progressCallback);

		public static IntPtr ai_ImportFile(string filename, uint flags, ProgressCallback progressCallback)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiImportFileEx(string filename, uint flags, IntPtr ptrFS, IntPtr ptrProps, ProgressCallback progressCallback);

		public static IntPtr ai_ImportFileEx(string filename, uint flags, IntPtr ptrFS, IntPtr ptrProp, ProgressCallback progressCallback)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern void _aiReleaseImport(IntPtr scene);

		public static void ai_ReleaseImport(IntPtr scene)
		{
		}

		[PreserveSig]
		private static extern void _aiGetExtensionList(IntPtr ptrExtensionList);

		public static void ai_GetExtensionList(out string strExtensionList)
		{
			strExtensionList = null;
		}

		[PreserveSig]
		private static extern IntPtr _aiGetErrorString();

		public static string ai_GetErrorString()
		{
			return null;
		}

		[PreserveSig]
		private static extern bool _aiIsExtensionSupported(IntPtr strExtension);

		public static bool ai_IsExtensionSupported(string strExtension)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiScene_HasMaterials(IntPtr ptrScene);

		public static bool aiScene_HasMaterials(IntPtr ptrScene)
		{
			return false;
		}

		[PreserveSig]
		private static extern uint _aiScene_GetNumMaterials(IntPtr ptrScene);

		public static uint aiScene_GetNumMaterials(IntPtr ptrScene)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern uint _aiScene_GetNumMeshes(IntPtr ptrScene);

		public static uint aiScene_GetNumMeshes(IntPtr ptrScene)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern uint _aiScene_GetNumAnimations(IntPtr ptrScene);

		public static uint aiScene_GetNumAnimations(IntPtr ptrScene)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern uint _aiScene_GetNumCameras(IntPtr ptrScene);

		public static uint aiScene_GetNumCameras(IntPtr ptrScene)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern uint _aiScene_GetNumLights(IntPtr ptrScene);

		public static uint aiScene_GetNumLights(IntPtr ptrScene)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern bool _aiScene_HasMeshes(IntPtr ptrScene);

		public static bool aiScene_HasMeshes(IntPtr ptrScene)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiScene_HasAnimation(IntPtr ptrScene);

		public static bool aiScene_HasAnimation(IntPtr ptrScene)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiScene_HasCameras(IntPtr ptrScene);

		public static bool aiScene_HasCameras(IntPtr ptrScene)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiScene_HasLights(IntPtr ptrScene);

		public static bool aiScene_HasLights(IntPtr ptrScene)
		{
			return false;
		}

		[PreserveSig]
		private static extern IntPtr _aiScene_GetRootNode(IntPtr ptrScene);

		public static IntPtr aiScene_GetRootNode(IntPtr ptrScene)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiScene_GetMaterial(IntPtr ptrScene, uint uintIndex);

		public static IntPtr aiScene_GetMaterial(IntPtr ptrScene, uint uintIndex)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiScene_GetMesh(IntPtr ptrScene, uint uintIndex);

		public static IntPtr aiScene_GetMesh(IntPtr ptrScene, uint uintIndex)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiScene_GetAnimation(IntPtr ptrScene, uint uintIndex);

		public static IntPtr aiScene_GetAnimation(IntPtr ptrScene, uint uintIndex)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiScene_GetCamera(IntPtr ptrScene, uint uintIndex);

		public static IntPtr aiScene_GetCamera(IntPtr ptrScene, uint uintIndex)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiScene_GetLight(IntPtr ptrScene, uint uintIndex);

		public static IntPtr aiScene_GetLight(IntPtr ptrScene, uint uintIndex)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiNode_GetName(IntPtr ptrNode);

		public static string aiNode_GetName(IntPtr ptrNode)
		{
			return null;
		}

		[PreserveSig]
		private static extern uint _aiNode_GetNumChildren(IntPtr ptrNode);

		public static uint aiNode_GetNumChildren(IntPtr ptrNode)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern uint _aiNode_GetNumMeshes(IntPtr ptrNode);

		public static uint aiNode_GetNumMeshes(IntPtr ptrNode)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern IntPtr _aiNode_GetChildren(IntPtr ptrNode, uint uintIndex);

		public static IntPtr aiNode_GetChildren(IntPtr ptrNode, uint uintIndex)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern uint _aiNode_GetMeshIndex(IntPtr ptrNode, uint uintIndex);

		public static uint aiNode_GetMeshIndex(IntPtr ptrNode, uint uintIndex)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern IntPtr _aiNode_GetParent(IntPtr ptrNode);

		public static IntPtr aiNode_GetParent(IntPtr ptrNode)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiNode_GetTransformation(IntPtr ptrNode);

		public static Matrix4x4 aiNode_GetTransformation(IntPtr ptrNode)
		{
			return default(Matrix4x4);
		}

		[PreserveSig]
		private static extern bool _aiMaterial_GetFloat(IntPtr ptrMat, string key, uint type, uint index, IntPtr floatOut);

		public static bool aiMaterial_GetFloat(IntPtr ptrMat, string key, uint type, uint index, out float floatOut)
		{
			floatOut = default(float);
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_GetInteger(IntPtr ptrMat, string key, uint type, uint index, IntPtr intOut);

		public static bool aiMaterial_GetInteger(IntPtr ptrMat, string key, uint type, uint index, out int intOut)
		{
			intOut = default(int);
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_GetString(IntPtr ptrMat, string strKey, uint uintType, uint uintIndex, IntPtr ptrValue);

		public static bool aiMaterial_GetString(IntPtr ptrMat, string strKey, uint uintType, uint uintIndex, out string strValue)
		{
			strValue = null;
			return false;
		}

		[PreserveSig]
		private static extern uint _aiMaterial_GetNumProperties(IntPtr ptrMat);

		public static uint aiMaterial_GetNumProperties(IntPtr ptrMat)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern IntPtr _aiMaterial_GetProperty(IntPtr ptrMaterial, uint uintIndex);

		public static IntPtr aiMaterial_GetProperty(IntPtr ptrMaterial, uint uintIndex)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiMaterialProperty_GetKey(IntPtr ptrMatProp);

		public static string aiMaterialProperty_GetKey(IntPtr ptrMatProp)
		{
			return null;
		}

		[PreserveSig]
		private static extern aiPropertyTypeInfo _aiMaterialProperty_GetType(IntPtr ptrPropMat);

		public static aiPropertyTypeInfo aiMaterialProperty_GetType(IntPtr ptrPropMat)
		{
			return default(aiPropertyTypeInfo);
		}

		[PreserveSig]
		private static extern uint _aiMaterialProperty_GetIndex(IntPtr ptrPropMat);

		public static uint aiMaterialProperty_GetIndex(IntPtr ptrPropMat)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern uint _aiMaterialProperty_GetDataSize(IntPtr ptrPropMat);

		public static uint aiMaterialProperty_GetDataSize(IntPtr ptrPropMat)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern IntPtr _aiMaterialProperty_GetDataPointer(IntPtr ptrPropMat);

		public static IntPtr aiMaterialProperty_GetDataPointer(IntPtr ptrPropMat)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern uint _aiMaterialProperty_GetSemantic(IntPtr ptrPropMat);

		public static uint aiMaterialProperty_GetSemantic(IntPtr ptrPropMat)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern IntPtr _aiMaterial_GetEmbeddedTextureName(IntPtr ptrTexture);

		public static string aiMaterial_GetEmbeddedTextureName(IntPtr ptrTexture)
		{
			return null;
		}

		[PreserveSig]
		private static extern void _aiMaterial_ReleaseEmbeddedTexture(IntPtr ptrTexture);

		public static void aiMaterial_ReleaseEmbeddedTexture(IntPtr ptrTexture)
		{
		}

		[PreserveSig]
		private static extern bool _aiMaterial_IsEmbeddedTextureCompressed(IntPtr ptrTexture);

		public static bool aiMaterial_IsEmbeddedTextureCompressed(IntPtr ptrTexture)
		{
			return false;
		}

		[PreserveSig]
		private static extern uint _aiMaterial_GetEmbeddedTextureDataSize(IntPtr ptrTexture);

		public static uint aiMaterial_GetEmbeddedTextureDataSize(IntPtr ptrTexture)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern IntPtr _aiMaterial_GetEmbeddedTextureDataPointer(IntPtr ptrTexture);

		public static IntPtr aiMaterial_GetEmbeddedTextureDataPointer(IntPtr ptrTexture)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern int _aiMaterial_GetEmbeddedTextureWidth(IntPtr ptrTexture);

		public static int aiMaterial_GetEmbeddedTextureWidth(IntPtr ptrTexture)
		{
			return 0;
		}

		[PreserveSig]
		private static extern int _aiMaterial_GetEmbeddedTextureHeight(IntPtr ptrTexture);

		public static int aiMaterial_GetEmbeddedTextureHeight(IntPtr ptrTexture)
		{
			return 0;
		}

		[PreserveSig]
		private static extern IntPtr _aiScene_GetEmbeddedTexture(IntPtr ptrScene, string strFilename);

		public static IntPtr aiScene_GetEmbeddedTexture(IntPtr ptrScene, string strFilename)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern uint _aiMaterial_GetTextureCount(IntPtr ptrMat, uint uintType);

		public static uint aiMaterial_GetTextureCount(IntPtr ptrMat, uint uintType)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_HasTextureDiffuse(IntPtr ptrMat, uint uintType);

		public static bool aiMaterial_HasTextureDiffuse(IntPtr ptrMat, uint uintType)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_GetTextureDiffuse(IntPtr ptrMat, uint uintType, IntPtr strPath, IntPtr uintMapping, IntPtr uintUvIndex, IntPtr floatBlend, IntPtr uintOp, IntPtr uintMapMode);

		public static bool aiMaterial_GetTextureDiffuse(IntPtr ptrMat, uint uintType, out string strPath, out uint uintMapping, out uint uintUvIndex, out float floatBlend, out uint uintOp, out uint uintMapMode)
		{
			strPath = null;
			uintMapping = default(uint);
			uintUvIndex = default(uint);
			floatBlend = default(float);
			uintOp = default(uint);
			uintMapMode = default(uint);
			return false;
		}

		[PreserveSig]
		private static extern uint _aiMaterial_GetNumTextureDiffuse(IntPtr ptrMat);

		public static uint aiMaterial_GetNumTextureDiffuse(IntPtr ptrMat)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_HasTextureEmissive(IntPtr ptrMat, uint uintIndex);

		public static bool aiMaterial_HasTextureEmissive(IntPtr ptrMat, uint uintIndex)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_GetTextureEmissive(IntPtr ptrMat, uint uintIndex, IntPtr strPath, IntPtr uintMapping, IntPtr uintUvIndex, IntPtr floatBlend, IntPtr uintOp, IntPtr uintMapMode);

		public static bool aiMaterial_GetTextureEmissive(IntPtr ptrMat, uint uintIndex, out string strPath, out uint uintMapping, out uint uintUvIndex, out float floatBlend, out uint uintOp, out uint uintMapMode)
		{
			strPath = null;
			uintMapping = default(uint);
			uintUvIndex = default(uint);
			floatBlend = default(float);
			uintOp = default(uint);
			uintMapMode = default(uint);
			return false;
		}

		[PreserveSig]
		private static extern uint _aiMaterial_GetNumTextureEmissive(IntPtr ptrMat);

		public static uint aiMaterial_GetNumTextureEmissive(IntPtr ptrMat)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_HasTextureSpecular(IntPtr ptrMat, uint uintIndex);

		public static bool aiMaterial_HasTextureSpecular(IntPtr ptrMat, uint uintIndex)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_GetTextureSpecular(IntPtr ptrMat, uint uintIndex, IntPtr strPath, IntPtr uintMapping, IntPtr uintUvIndex, IntPtr floatBlend, IntPtr uintOp, IntPtr uintMapMode);

		public static bool aiMaterial_GetTextureSpecular(IntPtr ptrMat, uint uintIndex, out string strPath, out uint uintMapping, out uint uintUvIndex, out float floatBlend, out uint uintOp, out uint uintMapMode)
		{
			strPath = null;
			uintMapping = default(uint);
			uintUvIndex = default(uint);
			floatBlend = default(float);
			uintOp = default(uint);
			uintMapMode = default(uint);
			return false;
		}

		[PreserveSig]
		private static extern uint _aiMaterial_GetNumTextureSpecular(IntPtr ptrMat);

		public static uint aiMaterial_GetNumTextureSpecular(IntPtr ptrMat)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_HasTextureNormals(IntPtr ptrMat, uint uintIndex);

		public static bool aiMaterial_HasTextureNormals(IntPtr ptrMat, uint uintIndex)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_GetTextureNormals(IntPtr ptrMat, uint uintIndex, IntPtr strPath, IntPtr uintMapping, IntPtr uintUvIndex, IntPtr floatBlend, IntPtr uintOp, IntPtr uintMapMode);

		public static bool aiMaterial_GetTextureNormals(IntPtr ptrMat, uint uintIndex, out string strPath, out uint uintMapping, out uint uintUvIndex, out float floatBlend, out uint uintOp, out uint uintMapMode)
		{
			strPath = null;
			uintMapping = default(uint);
			uintUvIndex = default(uint);
			floatBlend = default(float);
			uintOp = default(uint);
			uintMapMode = default(uint);
			return false;
		}

		[PreserveSig]
		private static extern uint _aiMaterial_GetNumTextureNormals(IntPtr ptrMat);

		public static uint aiMaterial_GetNumTextureNormals(IntPtr ptrMat)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_HasTextureHeight(IntPtr ptrMat, uint uintIndex);

		public static bool aiMaterial_HasTextureHeight(IntPtr ptrMat, uint uintIndex)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_GetTextureHeight(IntPtr ptrMat, uint uintIndex, IntPtr strPath, IntPtr uintMapping, IntPtr uintUvIndex, IntPtr floatBlend, IntPtr uintOp, IntPtr uintMapMode);

		public static bool aiMaterial_GetTextureHeight(IntPtr ptrMat, uint uintIndex, out string strPath, out uint uintMapping, out uint uintUvIndex, out float floatBlend, out uint uintOp, out uint uintMapMode)
		{
			strPath = null;
			uintMapping = default(uint);
			uintUvIndex = default(uint);
			floatBlend = default(float);
			uintOp = default(uint);
			uintMapMode = default(uint);
			return false;
		}

		[PreserveSig]
		private static extern uint _aiMaterial_GetNumTextureHeight(IntPtr ptrMat);

		public static uint aiMaterial_GetNumTextureHeight(IntPtr ptrMat)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_HasTextureOcclusion(IntPtr ptrMat, uint uintIndex);

		public static bool aiMaterial_HasTextureOcclusion(IntPtr ptrMat, uint uintIndex)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_GetTextureOcclusion(IntPtr ptrMat, uint uintIndex, IntPtr strPath, IntPtr uintMapping, IntPtr uintUvIndex, IntPtr floatBlend, IntPtr uintOp, IntPtr uintMapMode);

		public static bool aiMaterial_GetTextureOcclusion(IntPtr ptrMat, uint uintIndex, out string strPath, out uint uintMapping, out uint uintUvIndex, out float floatBlend, out uint uintOp, out uint uintMapMode)
		{
			strPath = null;
			uintMapping = default(uint);
			uintUvIndex = default(uint);
			floatBlend = default(float);
			uintOp = default(uint);
			uintMapMode = default(uint);
			return false;
		}

		[PreserveSig]
		private static extern uint _aiMaterial_GetNumTextureOcclusion(IntPtr ptrMat);

		public static uint aiMaterial_GetNumTextureOcclusion(IntPtr ptrMat)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_HasTextureMetallic(IntPtr ptrMat, uint uintIndex);

		public static bool aiMaterial_HasTextureMetallic(IntPtr ptrMat, uint uintIndex)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_GetTextureMetallic(IntPtr ptrMat, uint uintIndex, IntPtr strPath, IntPtr uintMapping, IntPtr uintUvIndex, IntPtr floatBlend, IntPtr uintOp, IntPtr uintMapMode);

		public static bool aiMaterial_GetTextureMetallic(IntPtr ptrMat, uint uintIndex, out string strPath, out uint uintMapping, out uint uintUvIndex, out float floatBlend, out uint uintOp, out uint uintMapMode)
		{
			strPath = null;
			uintMapping = default(uint);
			uintUvIndex = default(uint);
			floatBlend = default(float);
			uintOp = default(uint);
			uintMapMode = default(uint);
			return false;
		}

		[PreserveSig]
		private static extern uint _aiMaterial_GetNumTextureMetallic(IntPtr ptrMat);

		public static uint aiMaterial_GetNumTextureMetallic(IntPtr ptrMat)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_HasAmbient(IntPtr ptrMat);

		public static bool aiMaterial_HasAmbient(IntPtr ptrMat)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_GetAmbient(IntPtr ptrMat, IntPtr colorOut);

		public static bool aiMaterial_GetAmbient(IntPtr ptrMat, out Color colorOut)
		{
			colorOut = default(Color);
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_HasDiffuse(IntPtr ptrMat);

		public static bool aiMaterial_HasDiffuse(IntPtr ptrMat)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_GetDiffuse(IntPtr ptrMat, IntPtr colorOut);

		public static bool aiMaterial_GetDiffuse(IntPtr ptrMat, out Color colorOut)
		{
			colorOut = default(Color);
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_HasSpecular(IntPtr ptrMat);

		public static bool aiMaterial_HasSpecular(IntPtr ptrMat)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_GetSpecular(IntPtr ptrMat, IntPtr colorOut);

		public static bool aiMaterial_GetSpecular(IntPtr ptrMat, out Color colorOut)
		{
			colorOut = default(Color);
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_HasEmissive(IntPtr ptrMat);

		public static bool aiMaterial_HasEmissive(IntPtr ptrMat)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_GetEmissive(IntPtr ptrMat, IntPtr colorOut);

		public static bool aiMaterial_GetEmissive(IntPtr ptrMat, out Color colorOut)
		{
			colorOut = default(Color);
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_HasName(IntPtr ptrMat);

		public static bool aiMaterial_HasName(IntPtr ptrMat)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_GetName(IntPtr ptrMat, IntPtr strName);

		public static bool aiMaterial_GetName(IntPtr ptrMat, out string strName)
		{
			strName = null;
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_HasBumpScaling(IntPtr ptrMat);

		public static bool aiMaterial_HasBumpScaling(IntPtr ptrMat)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_GetBumpScaling(IntPtr ptrMat, IntPtr floatOut);

		public static bool aiMaterial_GetBumpScaling(IntPtr ptrMat, out float floatOut)
		{
			floatOut = default(float);
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_HasShininess(IntPtr ptrMat);

		public static bool aiMaterial_HasShininess(IntPtr ptrMat)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_GetShininess(IntPtr ptrMat, IntPtr floatOut);

		public static bool aiMaterial_GetShininess(IntPtr ptrMat, out float floatOut)
		{
			floatOut = default(float);
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_HasShininessStrength(IntPtr ptrMat);

		public static bool aiMaterial_HasShininessStrength(IntPtr ptrMat)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_GetShininessStrength(IntPtr ptrMat, IntPtr floatOut);

		public static bool aiMaterial_GetShininessStrength(IntPtr ptrMat, out float floatOut)
		{
			floatOut = default(float);
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_HasOpacity(IntPtr ptrMat);

		public static bool aiMaterial_HasOpacity(IntPtr ptrMat)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMaterial_GetOpacity(IntPtr ptrMat, IntPtr floatOut);

		public static bool aiMaterial_GetOpacity(IntPtr ptrMat, out float floatOut)
		{
			floatOut = default(float);
			return false;
		}

		[PreserveSig]
		private static extern IntPtr _aiMesh_GetAnimMesh(IntPtr ptrMesh, uint uintIndex);

		public static IntPtr aiMesh_GetAnimMesh(IntPtr ptrMesh, uint uintIndex)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiAnimMesh_GetName(IntPtr ptrMesh);

		public static string aiAnimMesh_GetName(IntPtr ptrMesh)
		{
			return null;
		}

		[PreserveSig]
		private static extern uint _aiMesh_GetAnimMeshCount(IntPtr ptrMesh);

		public static uint aiMesh_GetAnimMeshCount(IntPtr ptrMesh)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern uint _aiAnimMesh_GetVerticesCount(IntPtr ptrMesh);

		public static uint aiAnimMesh_GetVerticesCount(IntPtr ptrMesh)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern bool _aiAnimMesh_HasPositions(IntPtr ptrMesh);

		public static bool aiAnimMesh_HasPositions(IntPtr ptrMesh)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiAnimMesh_HasNormals(IntPtr ptrMesh);

		public static bool aiAnimMesh_HasNormals(IntPtr ptrMesh)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiAnimMesh_HasTangentsAndBitangents(IntPtr ptrMesh);

		public static bool aiAnimMesh_HasTangentsAndBitangents(IntPtr ptrMesh)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiAnimMesh_HasTextureCoords(IntPtr ptrMesh, uint uintIndex);

		public static bool aiAnimMesh_HasTextureCoords(IntPtr ptrMesh, uint uintIndex)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiAnimMesh_HasVertexColors(IntPtr ptrMesh, uint uintIndex);

		public static bool aiAnimMesh_HasVertexColors(IntPtr ptrMesh, uint uintIndex)
		{
			return false;
		}

		[PreserveSig]
		private static extern IntPtr _aiAnimMesh_GetVertex(IntPtr ptrMesh, uint uintIndex);

		public static Vector3 aiAnimMesh_GetVertex(IntPtr ptrMesh, uint uintIndex)
		{
			return default(Vector3);
		}

		[PreserveSig]
		private static extern IntPtr _aiAnimMesh_GetNormal(IntPtr ptrMesh, uint uintIndex);

		public static Vector3 aiAnimMesh_GetNormal(IntPtr ptrMesh, uint uintIndex)
		{
			return default(Vector3);
		}

		[PreserveSig]
		private static extern IntPtr _aiAnimMesh_GetTangent(IntPtr ptrMesh, uint uintIndex);

		public static Vector3 aiAnimMesh_GetTangent(IntPtr ptrMesh, uint uintIndex)
		{
			return default(Vector3);
		}

		[PreserveSig]
		private static extern IntPtr _aiAnimMesh_GetBitangent(IntPtr ptrMesh, uint uintIndex);

		public static Vector3 aiAnimMesh_GetBitangent(IntPtr ptrMesh, uint uintIndex)
		{
			return default(Vector3);
		}

		[PreserveSig]
		private static extern IntPtr _aiAnimMesh_GetTextureCoord(IntPtr ptrMesh, uint uintChannel, uint uintIndex);

		public static Vector2 aiAnimMesh_GetTextureCoord(IntPtr ptrMesh, uint uintChannel, uint uintIndex)
		{
			return default(Vector2);
		}

		[PreserveSig]
		private static extern IntPtr _aiAnimMesh_GetVertexColor(IntPtr ptrMesh, uint uintChannel, uint uintIndex);

		public static Color aiAnimMesh_GetVertexColor(IntPtr ptrMesh, uint uintChannel, uint uintIndex)
		{
			return default(Color);
		}

		[PreserveSig]
		private static extern float _aiAnimMesh_GetWeight(IntPtr ptrMesh);

		public static float aiAnimMesh_GetWeight(IntPtr ptrMesh)
		{
			return 0f;
		}

		[PreserveSig]
		private static extern uint _aiMesh_VertexCount(IntPtr ptrMesh);

		public static uint aiMesh_VertexCount(IntPtr ptrMesh)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern bool _aiMesh_HasNormals(IntPtr ptrMesh);

		public static bool aiMesh_HasNormals(IntPtr ptrMesh)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMesh_HasTangentsAndBitangents(IntPtr ptrMesh);

		public static bool aiMesh_HasTangentsAndBitangents(IntPtr ptrMesh)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMesh_HasTextureCoords(IntPtr ptrMesh, uint uintIndex);

		public static bool aiMesh_HasTextureCoords(IntPtr ptrMesh, uint uintIndex)
		{
			return false;
		}

		[PreserveSig]
		private static extern bool _aiMesh_HasVertexColors(IntPtr ptrMesh, uint uintIndex);

		public static bool aiMesh_HasVertexColors(IntPtr ptrMesh, uint uintIndex)
		{
			return false;
		}

		[PreserveSig]
		private static extern IntPtr _aiMesh_GetVertex(IntPtr ptrMesh, uint uintIndex);

		public static Vector3 aiMesh_GetVertex(IntPtr ptrMesh, uint uintIndex)
		{
			return default(Vector3);
		}

		[PreserveSig]
		private static extern IntPtr _aiMesh_GetNormal(IntPtr ptrMesh, uint uintIndex);

		public static Vector3 aiMesh_GetNormal(IntPtr ptrMesh, uint uintIndex)
		{
			return default(Vector3);
		}

		[PreserveSig]
		private static extern IntPtr _aiMesh_GetTangent(IntPtr ptrMesh, uint uintIndex);

		public static Vector3 aiMesh_GetTangent(IntPtr ptrMesh, uint uintIndex)
		{
			return default(Vector3);
		}

		[PreserveSig]
		private static extern IntPtr _aiMesh_GetBitangent(IntPtr ptrMesh, uint uintIndex);

		public static Vector3 aiMesh_GetBitangent(IntPtr ptrMesh, uint uintIndex)
		{
			return default(Vector3);
		}

		[PreserveSig]
		private static extern IntPtr _aiMesh_GetTextureCoord(IntPtr ptrMesh, uint uintChannel, uint uintIndex);

		public static Vector2 aiMesh_GetTextureCoord(IntPtr ptrMesh, uint uintChannel, uint uintIndex)
		{
			return default(Vector2);
		}

		[PreserveSig]
		private static extern IntPtr _aiMesh_GetVertexColor(IntPtr ptrMesh, uint uintChannel, uint uintIndex);

		public static Color aiMesh_GetVertexColor(IntPtr ptrMesh, uint uintChannel, uint uintIndex)
		{
			return default(Color);
		}

		[PreserveSig]
		private static extern uint _aiMesh_GetMatrialIndex(IntPtr ptrMesh);

		public static uint aiMesh_GetMatrialIndex(IntPtr ptrMesh)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern IntPtr _aiMesh_GetName(IntPtr ptrMesh);

		public static string aiMesh_GetName(IntPtr ptrMesh)
		{
			return null;
		}

		[PreserveSig]
		private static extern bool _aiMesh_HasFaces(IntPtr ptrMesh);

		public static bool aiMesh_HasFaces(IntPtr ptrMesh)
		{
			return false;
		}

		[PreserveSig]
		private static extern uint _aiMesh_GetNumFaces(IntPtr ptrMesh);

		public static uint aiMesh_GetNumFaces(IntPtr ptrMesh)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern IntPtr _aiMesh_GetFace(IntPtr ptrMesh, uint uintIndex);

		public static IntPtr aiMesh_GetFace(IntPtr ptrMesh, uint uintIndex)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern bool _aiMesh_HasBones(IntPtr ptrMesh);

		public static bool aiMesh_HasBones(IntPtr ptrMesh)
		{
			return false;
		}

		[PreserveSig]
		private static extern uint _aiMesh_GetNumBones(IntPtr ptrMesh);

		public static uint aiMesh_GetNumBones(IntPtr ptrMesh)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern IntPtr _aiMesh_GetBone(IntPtr ptrMesh, uint uintIndex);

		public static IntPtr aiMesh_GetBone(IntPtr ptrMesh, uint uintIndex)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern uint _aiFace_GetNumIndices(IntPtr ptrFace);

		public static uint aiFace_GetNumIndices(IntPtr ptrFace)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern uint _aiFace_GetIndex(IntPtr ptrFace, uint uintIndex);

		public static uint aiFace_GetIndex(IntPtr ptrFace, uint uintIndex)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern IntPtr _aiBone_GetName(IntPtr ptrBone);

		public static string aiBone_GetName(IntPtr ptrBone)
		{
			return null;
		}

		[PreserveSig]
		private static extern uint _aiBone_GetNumWeights(IntPtr ptrBone);

		public static uint aiBone_GetNumWeights(IntPtr ptrBone)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern IntPtr _aiBone_GetWeights(IntPtr ptrBone, uint uintIndex);

		public static IntPtr aiBone_GetWeights(IntPtr ptrBone, uint uintIndex)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiBone_GetOffsetMatrix(IntPtr ptrBone);

		public static Matrix4x4 aiBone_GetOffsetMatrix(IntPtr ptrBone)
		{
			return default(Matrix4x4);
		}

		[PreserveSig]
		private static extern float _aiVertexWeight_GetWeight(IntPtr ptrVweight);

		public static float aiVertexWeight_GetWeight(IntPtr ptrVweight)
		{
			return 0f;
		}

		[PreserveSig]
		private static extern uint _aiVertexWeight_GetVertexId(IntPtr ptrVweight);

		public static uint aiVertexWeight_GetVertexId(IntPtr ptrVweight)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern IntPtr _aiAnimation_GetName(IntPtr ptrAnimation);

		public static string aiAnimation_GetName(IntPtr ptrAnimation)
		{
			return null;
		}

		[PreserveSig]
		private static extern float _aiAnimation_GetDuraction(IntPtr ptrAnimation);

		public static float aiAnimation_GetDuraction(IntPtr ptrAnimation)
		{
			return 0f;
		}

		[PreserveSig]
		private static extern float _aiAnimation_GetTicksPerSecond(IntPtr ptrAnimation);

		public static float aiAnimation_GetTicksPerSecond(IntPtr ptrAnimation)
		{
			return 0f;
		}

		[PreserveSig]
		private static extern uint _aiAnimation_GetNumChannels(IntPtr ptrAnimation);

		public static uint aiAnimation_GetNumChannels(IntPtr ptrAnimation)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern uint _aiAnimation_GetNumMorphChannels(IntPtr ptrAnimation);

		public static uint aiAnimation_GetNumMorphChannels(IntPtr ptrAnimation)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern IntPtr _aiAnimation_GetMeshMorphAnim(IntPtr ptrAnimation, uint uintIndex);

		public static IntPtr aiAnimation_GetMeshMorphAnim(IntPtr ptrAnimation, uint uintIndex)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern uint _aiAnimation_GetNumMeshChannels(IntPtr ptrAnimation);

		public static uint aiAnimation_GetNumMeshChannels(IntPtr ptrAnimation)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern IntPtr _aiAnimation_GetAnimationChannel(IntPtr ptrAnimation, uint uintIndex);

		public static IntPtr aiAnimation_GetAnimationChannel(IntPtr ptrAnimation, uint uintIndex)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiNodeAnim_GetNodeName(IntPtr ptrNodeAnim);

		public static string aiNodeAnim_GetNodeName(IntPtr ptrNodeAnim)
		{
			return null;
		}

		[PreserveSig]
		private static extern IntPtr _aiMeshMorphAnim_GetName(IntPtr ptrNodeAnim);

		public static string aiMeshMorphAnim_GetName(IntPtr ptrNodeAnim)
		{
			return null;
		}

		[PreserveSig]
		private static extern uint _aiMeshMorphAnim_GetNumKeys(IntPtr ptrNodeAnim);

		public static uint aiMeshMorphAnim_GetNumKeys(IntPtr ptrNodeAnim)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern uint _aiNodeAnim_GetNumPositionKeys(IntPtr ptrNodeAnim);

		public static uint aiNodeAnim_GetNumPositionKeys(IntPtr ptrNodeAnim)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern uint _aiNodeAnim_GetNumRotationKeys(IntPtr ptrNodeAnim);

		public static uint aiNodeAnim_GetNumRotationKeys(IntPtr ptrNodeAnim)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern uint _aiNodeAnim_GetNumScalingKeys(IntPtr ptrNodeAnim);

		public static uint aiNodeAnim_GetNumScalingKeys(IntPtr ptrNodeAnim)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern uint _aiNodeAnim_GetPostState(IntPtr ptrNodeAnim);

		public static uint aiNodeAnim_GetPostState(IntPtr ptrNodeAnim)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern uint _aiNodeAnim_GetPreState(IntPtr ptrNodeAnim);

		public static uint aiNodeAnim_GetPreState(IntPtr ptrNodeAnim)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern IntPtr _aiNodeAnim_GetPositionKey(IntPtr ptrNodeAnim, uint uintIndex);

		public static IntPtr aiNodeAnim_GetPositionKey(IntPtr ptrNodeAnim, uint uintIndex)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiMeshMorphAnim_GetMeshMorphKey(IntPtr ptrNodeAnim, uint uintIndex);

		public static IntPtr aiMeshMorphAnim_GetMeshMorphKey(IntPtr ptrNodeAnim, uint uintIndex)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiNodeAnim_GetRotationKey(IntPtr ptrNodeAnim, uint uintIndex);

		public static IntPtr aiNodeAnim_GetRotationKey(IntPtr ptrNodeAnim, uint uintIndex)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern IntPtr _aiNodeAnim_GetScalingKey(IntPtr ptrNodeAnim, uint uintIndex);

		public static IntPtr aiNodeAnim_GetScalingKey(IntPtr ptrNodeAnim, uint uintIndex)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern float _aiMeshMorphKey_GetTime(IntPtr ptrVectorKey);

		public static float aiMeshMorphKey_GetTime(IntPtr ptrMeshMorphKey)
		{
			return 0f;
		}

		[PreserveSig]
		private static extern uint _aiMeshMorphKey_GetNumValues(IntPtr ptrVectorKey);

		public static uint aiMeshMorphKey_GetNumValues(IntPtr ptrMeshMorphKey)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern uint _aiMeshMorphKey_GetValue(IntPtr ptrVectorKey, uint uintIndex);

		public static uint aiMeshMorphKey_GetValue(IntPtr ptrMeshMorphKey, uint uintIndex)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern float _aiMeshMorphKey_GetWeight(IntPtr ptrVectorKey, uint uintIndex);

		public static float aiMeshMorphKey_GetWeight(IntPtr ptrMeshMorphKey, uint uintIndex)
		{
			return 0f;
		}

		[PreserveSig]
		private static extern float _aiVectorKey_GetTime(IntPtr ptrVectorKey);

		public static float aiVectorKey_GetTime(IntPtr ptrVectorKey)
		{
			return 0f;
		}

		[PreserveSig]
		private static extern IntPtr _aiVectorKey_GetValue(IntPtr ptrVectorKey);

		public static float[] aiVectorKey_GetValue(IntPtr ptrVectorKey)
		{
			return null;
		}

		[PreserveSig]
		private static extern float _aiQuatKey_GetTime(IntPtr ptrQuatKey);

		public static float aiQuatKey_GetTime(IntPtr ptrQuatKey)
		{
			return 0f;
		}

		[PreserveSig]
		private static extern IntPtr _aiQuatKey_GetValue(IntPtr ptrQuatKey);

		public static float[] aiQuatKey_GetValue(IntPtr ptrQuatKey)
		{
			return null;
		}

		[PreserveSig]
		private static extern float _aiCamera_GetAspect(IntPtr ptrCamera);

		public static float aiCamera_GetAspect(IntPtr ptrCamera)
		{
			return 0f;
		}

		[PreserveSig]
		private static extern float _aiCamera_GetClipPlaneFar(IntPtr ptrCamera);

		public static float aiCamera_GetClipPlaneFar(IntPtr ptrCamera)
		{
			return 0f;
		}

		[PreserveSig]
		private static extern float _aiCamera_GetClipPlaneNear(IntPtr ptrCamera);

		public static float aiCamera_GetClipPlaneNear(IntPtr ptrCamera)
		{
			return 0f;
		}

		[PreserveSig]
		private static extern float _aiCamera_GetHorizontalFOV(IntPtr ptrCamera);

		public static float aiCamera_GetHorizontalFOV(IntPtr ptrCamera)
		{
			return 0f;
		}

		[PreserveSig]
		private static extern IntPtr _aiCamera_GetLookAt(IntPtr ptrCamera);

		public static Vector3 aiCamera_GetLookAt(IntPtr ptrCamera)
		{
			return default(Vector3);
		}

		[PreserveSig]
		private static extern IntPtr _aiCamera_GetName(IntPtr ptrCamera);

		public static string aiCamera_GetName(IntPtr ptrCamera)
		{
			return null;
		}

		[PreserveSig]
		private static extern IntPtr _aiCamera_GetPosition(IntPtr ptrCamera);

		public static Vector3 aiCamera_GetPosition(IntPtr ptrCamera)
		{
			return default(Vector3);
		}

		[PreserveSig]
		private static extern IntPtr _aiCamera_GetUp(IntPtr ptrCamera);

		public static Vector3 aiCamera_GetUp(IntPtr ptrCamera)
		{
			return default(Vector3);
		}

		[PreserveSig]
		private static extern float _aiLight_GetAngleInnerCone(IntPtr ptrLight);

		public static float aiLight_GetAngleInnerCone(IntPtr ptrLight)
		{
			return 0f;
		}

		[PreserveSig]
		private static extern float _aiLight_GetAngleOuterCone(IntPtr ptrLight);

		public static float aiLight_GetAngleOuterCone(IntPtr ptrLight)
		{
			return 0f;
		}

		[PreserveSig]
		private static extern float _aiLight_GetAttenuationConstant(IntPtr ptrLight);

		public static float aiLight_GetAttenuationConstant(IntPtr ptrLight)
		{
			return 0f;
		}

		[PreserveSig]
		private static extern float _aiLight_GetAttenuationLinear(IntPtr ptrLight);

		public static float aiLight_GetAttenuationLinear(IntPtr ptrLight)
		{
			return 0f;
		}

		[PreserveSig]
		private static extern float _aiLight_GetAttenuationQuadratic(IntPtr ptrLight);

		public static float aiLight_GetAttenuationQuadratic(IntPtr ptrLight)
		{
			return 0f;
		}

		[PreserveSig]
		private static extern IntPtr _aiLight_GetColorAmbient(IntPtr ptrLight);

		public static Color aiLight_GetColorAmbient(IntPtr ptrLight)
		{
			return default(Color);
		}

		[PreserveSig]
		private static extern IntPtr _aiLight_GetColorDiffuse(IntPtr ptrLight);

		public static Color aiLight_GetColorDiffuse(IntPtr ptrLight)
		{
			return default(Color);
		}

		[PreserveSig]
		private static extern IntPtr _aiLight_GetColorSpecular(IntPtr ptrLight);

		public static Color aiLight_GetColorSpecular(IntPtr ptrLight)
		{
			return default(Color);
		}

		[PreserveSig]
		private static extern IntPtr _aiLight_GetDirection(IntPtr ptrLight);

		public static Vector3 aiLight_GetDirection(IntPtr ptrLight)
		{
			return default(Vector3);
		}

		[PreserveSig]
		private static extern IntPtr _aiLight_GetName(IntPtr ptrLight);

		public static string aiLight_GetName(IntPtr ptrLight)
		{
			return null;
		}

		[PreserveSig]
		private static extern uint _aiScene_GetMetadataCount(IntPtr ptrScene);

		public static uint aiScene_GetMetadataCount(IntPtr ptrScene)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern IntPtr _aiScene_GetMetadataKey(IntPtr ptrScene, uint uintIndex);

		public static string aiScene_GetMetadataKey(IntPtr ptrScene, uint uintIndex)
		{
			return null;
		}

		[PreserveSig]
		private static extern int _aiScene_GetMetadataType(IntPtr ptrScene, uint uintIndex);

		public static AssimpMetadataType aiScene_GetMetadataType(IntPtr ptrScene, uint uintIndex)
		{
			return default(AssimpMetadataType);
		}

		[PreserveSig]
		private static extern IntPtr _aiScene_GetMetadataValue(IntPtr ptrScene, uint uintIndex);

		public static bool aiScene_GetMetadataBoolValue(IntPtr ptrScene, uint uintIndex)
		{
			return false;
		}

		public static int aiScene_GetMetadataInt32Value(IntPtr ptrScene, uint uintIndex)
		{
			return 0;
		}

		public static long aiScene_GetMetadataInt64Value(IntPtr ptrScene, uint uintIndex)
		{
			return 0L;
		}

		public static float aiScene_GetMetadataFloatValue(IntPtr ptrScene, uint uintIndex)
		{
			return 0f;
		}

		public static double aiScene_GetMetadataDoubleValue(IntPtr ptrScene, uint uintIndex)
		{
			return 0.0;
		}

		public static string aiScene_GetMetadataStringValue(IntPtr ptrScene, uint uintIndex)
		{
			return null;
		}

		public static Vector3 aiScene_GetMetadataVectorValue(IntPtr ptrScene, uint uintIndex)
		{
			return default(Vector3);
		}

		[PreserveSig]
		private static extern uint _aiNode_GetMetadataCount(IntPtr ptrNode);

		public static uint aiNode_GetMetadataCount(IntPtr ptrNode)
		{
			return 0u;
		}

		[PreserveSig]
		private static extern IntPtr _aiNode_GetMetadataKey(IntPtr ptrNode, uint uintIndex);

		public static string aiNode_GetMetadataKey(IntPtr ptrNode, uint uintIndex)
		{
			return null;
		}

		[PreserveSig]
		private static extern int _aiNode_GetMetadataType(IntPtr ptrNode, uint uintIndex);

		public static AssimpMetadataType aiNode_GetMetadataType(IntPtr ptrNode, uint uintIndex)
		{
			return default(AssimpMetadataType);
		}

		[PreserveSig]
		private static extern IntPtr _aiNode_GetMetadataValue(IntPtr ptrNode, uint uintIndex);

		public static bool aiNode_GetMetadataBoolValue(IntPtr ptrNode, uint uintIndex)
		{
			return false;
		}

		public static int aiNode_GetMetadataInt32Value(IntPtr ptrNode, uint uintIndex)
		{
			return 0;
		}

		public static long aiNode_GetMetadataInt64Value(IntPtr ptrNode, uint uintIndex)
		{
			return 0L;
		}

		public static float aiNode_GetMetadataFloatValue(IntPtr ptrNode, uint uintIndex)
		{
			return 0f;
		}

		public static double aiNode_GetMetadataDoubleValue(IntPtr ptrNode, uint uintIndex)
		{
			return 0.0;
		}

		public static string aiNode_GetMetadataStringValue(IntPtr ptrNode, uint uintIndex)
		{
			return null;
		}

		public static Vector3 aiNode_GetMetadataVectorValue(IntPtr ptrNode, uint uintIndex)
		{
			return default(Vector3);
		}

		public static GCHandle LockGc(object value)
		{
			return default(GCHandle);
		}

		public static IntPtr AllocHGlobal<T>()
		{
			return (IntPtr)0;
		}

		public static T ReadStruct<T>(IntPtr pointer, bool dealloc = true)
		{
			return default(T);
		}

		public static byte[] StringToByteArray(string str, int length, bool utf8 = false)
		{
			return null;
		}

		public static string ByteArrayToString(byte[] value, bool utf8 = false)
		{
			return null;
		}

		public static GCHandle GetStringBuffer(string value)
		{
			return default(GCHandle);
		}

		public static IntPtr GetAssimpStringBuffer(string value)
		{
			return (IntPtr)0;
		}

		public static GCHandle GetNewStringBuffer(out byte[] byteArray)
		{
			byteArray = null;
			return default(GCHandle);
		}

		public static string ReadStringFromPointer(IntPtr pointer)
		{
			return null;
		}

		public static bool GetNewBool(IntPtr pointer)
		{
			return false;
		}

		public static byte GetNewByte(IntPtr pointer)
		{
			return 0;
		}

		public static int GetNewInt32(IntPtr pointer)
		{
			return 0;
		}

		public static long GetNewInt64(IntPtr pointer)
		{
			return 0L;
		}

		public static float GetNewFloat(IntPtr pointer)
		{
			return 0f;
		}

		public static double GetNewDouble(IntPtr pointer)
		{
			return 0.0;
		}

		public static Matrix4x4 GetNewMatrix4x4(IntPtr pointer)
		{
			return default(Matrix4x4);
		}

		public static GCHandle Matrix4x4ToAssimp(Vector3 translation, Vector3 rotation, Vector3 scale)
		{
			return default(GCHandle);
		}

		public static float[] ReadFloatArray(IntPtr pointer, int size)
		{
			return null;
		}

		public static double[] ReadDoubleArray(IntPtr pointer, int size)
		{
			return null;
		}

		public static int[] ReadIntArray(IntPtr pointer, int size)
		{
			return null;
		}

		public static byte[] ReadByteArray(IntPtr pointer, int size)
		{
			return null;
		}
	}
}
