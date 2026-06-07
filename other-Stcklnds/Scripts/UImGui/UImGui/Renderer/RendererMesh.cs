using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ImGuiNET;
using UImGui.Assets;
using UImGui.Texture;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Rendering;

namespace UImGui.Renderer
{
	internal sealed class RendererMesh : IRenderer
	{
		private const MeshUpdateFlags NoMeshChecks = MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds;

		private static readonly VertexAttributeDescriptor[] _vertexAttributes = new VertexAttributeDescriptor[3]
		{
			new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 2),
			new VertexAttributeDescriptor(VertexAttribute.TexCoord0, VertexAttributeFormat.Float32, 2),
			new VertexAttributeDescriptor(VertexAttribute.TexCoord1, VertexAttributeFormat.UInt32, 1)
		};

		private Material _material;

		private Mesh _mesh;

		private readonly Shader _shader;

		private readonly int _textureID;

		private readonly TextureManager _textureManager;

		private readonly MaterialPropertyBlock _materialProperties;

		private int _prevSubMeshCount = 1;

		public RendererMesh(ShaderResourcesAsset resources, TextureManager texManager)
		{
			_shader = resources.Shader.Mesh;
			_textureManager = texManager;
			_textureID = Shader.PropertyToID(resources.PropertyNames.Texture);
			_materialProperties = new MaterialPropertyBlock();
		}

		public void Initialize(ImGuiIOPtr io)
		{
			io.SetBackendRendererName("Unity Mesh");
			io.BackendFlags |= ImGuiBackendFlags.RendererHasVtxOffset;
			_material = new Material(_shader)
			{
				hideFlags = (HideFlags.HideInHierarchy | HideFlags.DontSaveInEditor | HideFlags.NotEditable | HideFlags.DontSaveInBuild)
			};
			_mesh = new Mesh
			{
				name = "DearImGui Mesh"
			};
			_mesh.MarkDynamic();
		}

		public void Shutdown(ImGuiIOPtr io)
		{
			io.SetBackendRendererName(null);
			if (_mesh != null)
			{
				UnityEngine.Object.Destroy(_mesh);
				_mesh = null;
			}
			if (_material != null)
			{
				UnityEngine.Object.Destroy(_material);
				_material = null;
			}
		}

		public void RenderDrawLists(CommandBuffer commandBuffer, ImDrawDataPtr drawData)
		{
			Vector2 fbSize = drawData.DisplaySize * drawData.FramebufferScale;
			if (!(fbSize.x <= 0f) && !(fbSize.y <= 0f) && drawData.TotalVtxCount != 0)
			{
				UpdateMesh(drawData);
				commandBuffer.BeginSample(Constants.ExecuteDrawCommandsMarker);
				CreateDrawCommands(commandBuffer, drawData, fbSize);
				commandBuffer.EndSample(Constants.ExecuteDrawCommandsMarker);
			}
		}

		private unsafe void UpdateMesh(ImDrawDataPtr drawData)
		{
			int num = 0;
			int i = 0;
			for (int cmdListsCount = drawData.CmdListsCount; i < cmdListsCount; i++)
			{
				num += drawData.CmdListsRange[i].CmdBuffer.Size;
			}
			if (_prevSubMeshCount != num)
			{
				_mesh.Clear(keepVertexLayout: true);
				_mesh.subMeshCount = (_prevSubMeshCount = num);
			}
			_mesh.SetVertexBufferParams(drawData.TotalVtxCount, _vertexAttributes);
			_mesh.SetIndexBufferParams(drawData.TotalIdxCount, IndexFormat.UInt16);
			int num2 = 0;
			int num3 = 0;
			List<SubMeshDescriptor> list = new List<SubMeshDescriptor>();
			int j = 0;
			for (int cmdListsCount2 = drawData.CmdListsCount; j < cmdListsCount2; j++)
			{
				ImDrawListPtr imDrawListPtr = drawData.CmdListsRange[j];
				NativeArray<ImDrawVert> data = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<ImDrawVert>((void*)imDrawListPtr.VtxBuffer.Data, imDrawListPtr.VtxBuffer.Size, Allocator.None);
				NativeArray<ushort> data2 = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<ushort>((void*)imDrawListPtr.IdxBuffer.Data, imDrawListPtr.IdxBuffer.Size, Allocator.None);
				_mesh.SetVertexBufferData(data, 0, num2, data.Length, 0, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
				_mesh.SetIndexBufferData(data2, 0, num3, data2.Length, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
				int k = 0;
				for (int size = imDrawListPtr.CmdBuffer.Size; k < size; k++)
				{
					ImDrawCmdPtr imDrawCmdPtr = imDrawListPtr.CmdBuffer[k];
					SubMeshDescriptor item = new SubMeshDescriptor
					{
						topology = MeshTopology.Triangles,
						indexStart = num3 + (int)imDrawCmdPtr.IdxOffset,
						indexCount = (int)imDrawCmdPtr.ElemCount,
						baseVertex = num2 + (int)imDrawCmdPtr.VtxOffset
					};
					list.Add(item);
				}
				num2 += data.Length;
				num3 += data2.Length;
			}
			_mesh.SetSubMeshes(list, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
			_mesh.UploadMeshData(markNoLongerReadable: false);
		}

		private void CreateDrawCommands(CommandBuffer commandBuffer, ImDrawDataPtr drawData, Vector2 fbSize)
		{
			IntPtr intPtr = IntPtr.Zero;
			Vector4 vector = new Vector4(drawData.DisplayPos.x, drawData.DisplayPos.y, drawData.DisplayPos.x, drawData.DisplayPos.y);
			Vector4 b = new Vector4(drawData.FramebufferScale.x, drawData.FramebufferScale.y, drawData.FramebufferScale.x, drawData.FramebufferScale.y);
			commandBuffer.SetViewport(new Rect(0f, 0f, fbSize.x, fbSize.y));
			commandBuffer.SetViewProjectionMatrices(Matrix4x4.Translate(new Vector3(0.5f / fbSize.x, 0.5f / fbSize.y, 0f)), Matrix4x4.Ortho(0f, fbSize.x, fbSize.y, 0f, 0f, 1f));
			int num = 0;
			int i = 0;
			for (int cmdListsCount = drawData.CmdListsCount; i < cmdListsCount; i++)
			{
				ImDrawListPtr parent_list = drawData.CmdListsRange[i];
				int num2 = 0;
				int size = parent_list.CmdBuffer.Size;
				while (num2 < size)
				{
					ImDrawCmdPtr cmd = parent_list.CmdBuffer[num2];
					if (cmd.UserCallback != IntPtr.Zero)
					{
						Marshal.GetDelegateForFunctionPointer<UserDrawCallback>(cmd.UserCallback)(parent_list, cmd);
					}
					else
					{
						Vector4 vector2 = Vector4.Scale(cmd.ClipRect - vector, b);
						if (!(vector2.x >= fbSize.x) && !(vector2.y >= fbSize.y) && !(vector2.z < 0f) && !(vector2.w < 0f))
						{
							if (intPtr != cmd.TextureId)
							{
								intPtr = cmd.TextureId;
								_textureManager.TryGetTexture(intPtr, out var texture);
								_materialProperties.SetTexture(_textureID, texture);
							}
							commandBuffer.EnableScissorRect(new Rect(vector2.x, fbSize.y - vector2.w, vector2.z - vector2.x, vector2.w - vector2.y));
							commandBuffer.DrawMesh(_mesh, Matrix4x4.identity, _material, num, -1, _materialProperties);
						}
					}
					num2++;
					num++;
				}
			}
			commandBuffer.DisableScissorRect();
		}
	}
}
