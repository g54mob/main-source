using System;
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
	internal sealed class RendererProcedural : IRenderer
	{
		private readonly Shader _shader;

		private readonly int _textureID;

		private readonly int _verticesID;

		private readonly int _baseVertexID;

		private readonly TextureManager _textureManager;

		private readonly MaterialPropertyBlock _materialProperties = new MaterialPropertyBlock();

		private Material _material;

		private ComputeBuffer _vertexBuffer;

		private GraphicsBuffer _indexBuffer;

		private ComputeBuffer _argumentsBuffer;

		public RendererProcedural(ShaderResourcesAsset resources, TextureManager texManager)
		{
			if (SystemInfo.graphicsShaderLevel < 45)
			{
				throw new Exception("Device not supported.");
			}
			_shader = resources.Shader.Procedural;
			_textureManager = texManager;
			_textureID = Shader.PropertyToID(resources.PropertyNames.Texture);
			_verticesID = Shader.PropertyToID(resources.PropertyNames.Vertices);
			_baseVertexID = Shader.PropertyToID(resources.PropertyNames.BaseVertex);
		}

		public void Initialize(ImGuiIOPtr io)
		{
			io.SetBackendRendererName("Unity Procedural");
			io.BackendFlags |= ImGuiBackendFlags.RendererHasVtxOffset;
			_material = new Material(_shader)
			{
				hideFlags = (HideFlags.HideInHierarchy | HideFlags.DontSaveInEditor | HideFlags.NotEditable | HideFlags.DontSaveInBuild)
			};
		}

		public void Shutdown(ImGuiIOPtr io)
		{
			io.SetBackendRendererName(null);
			if (_material != null)
			{
				UnityEngine.Object.Destroy(_material);
				_material = null;
			}
			_vertexBuffer?.Release();
			_vertexBuffer = null;
			_indexBuffer?.Release();
			_indexBuffer = null;
			_argumentsBuffer?.Release();
			_argumentsBuffer = null;
		}

		public void RenderDrawLists(CommandBuffer cmd, ImDrawDataPtr drawData)
		{
			Vector2 fbSize = drawData.DisplaySize * drawData.FramebufferScale;
			if (!(fbSize.x <= 0f) && !(fbSize.y <= 0f) && drawData.TotalVtxCount != 0)
			{
				UpdateBuffers(drawData);
				cmd.BeginSample(Constants.ExecuteDrawCommandsMarker);
				CreateDrawCommands(cmd, drawData, fbSize);
				cmd.EndSample(Constants.ExecuteDrawCommandsMarker);
			}
		}

		private unsafe void CreateOrResizeVtxBuffer(ref ComputeBuffer buffer, int count)
		{
			buffer?.Release();
			int count2 = ((count - 1) / 256 + 1) * 256;
			buffer = new ComputeBuffer(count2, sizeof(ImDrawVert));
		}

		private void CreateOrResizeIdxBuffer(ref GraphicsBuffer buffer, int count)
		{
			buffer?.Release();
			int count2 = ((count - 1) / 256 + 1) * 256;
			buffer = new GraphicsBuffer(GraphicsBuffer.Target.Index, count2, 2);
		}

		private void CreateOrResizeArgBuffer(ref ComputeBuffer buffer, int count)
		{
			buffer?.Release();
			int count2 = ((count - 1) / 256 + 1) * 256;
			buffer = new ComputeBuffer(count2, 4, ComputeBufferType.DrawIndirect);
		}

		private unsafe void UpdateBuffers(ImDrawDataPtr drawData)
		{
			int num = 0;
			int i = 0;
			for (int cmdListsCount = drawData.CmdListsCount; i < cmdListsCount; i++)
			{
				num += drawData.CmdListsRange[i].CmdBuffer.Size;
			}
			if (_vertexBuffer == null || _vertexBuffer.count < drawData.TotalVtxCount)
			{
				CreateOrResizeVtxBuffer(ref _vertexBuffer, drawData.TotalVtxCount);
			}
			if (_indexBuffer == null || _indexBuffer.count < drawData.TotalIdxCount)
			{
				CreateOrResizeIdxBuffer(ref _indexBuffer, drawData.TotalIdxCount);
			}
			if (_argumentsBuffer == null || _argumentsBuffer.count < num * 5)
			{
				CreateOrResizeArgBuffer(ref _argumentsBuffer, num * 5);
			}
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int j = 0;
			for (int cmdListsCount2 = drawData.CmdListsCount; j < cmdListsCount2; j++)
			{
				ImDrawListPtr imDrawListPtr = drawData.CmdListsRange[j];
				NativeArray<ImDrawVert> data = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<ImDrawVert>((void*)imDrawListPtr.VtxBuffer.Data, imDrawListPtr.VtxBuffer.Size, Allocator.None);
				NativeArray<ushort> data2 = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<ushort>((void*)imDrawListPtr.IdxBuffer.Data, imDrawListPtr.IdxBuffer.Size, Allocator.None);
				_vertexBuffer.SetData(data, 0, num2, data.Length);
				_indexBuffer.SetData(data2, 0, num3, data2.Length);
				int k = 0;
				for (int size = imDrawListPtr.CmdBuffer.Size; k < size; k++)
				{
					ImDrawCmdPtr imDrawCmdPtr = imDrawListPtr.CmdBuffer[k];
					int[] data3 = new int[5]
					{
						(int)imDrawCmdPtr.ElemCount,
						1,
						num3 + (int)imDrawCmdPtr.IdxOffset,
						num2,
						0
					};
					_argumentsBuffer.SetData(data3, 0, num4, 5);
					num4 += 5;
				}
				num2 += data.Length;
				num3 += data2.Length;
			}
		}

		private void CreateDrawCommands(CommandBuffer cmd, ImDrawDataPtr drawData, Vector2 fbSize)
		{
			IntPtr intPtr = IntPtr.Zero;
			Vector4 vector = new Vector4(drawData.DisplayPos.x, drawData.DisplayPos.y, drawData.DisplayPos.x, drawData.DisplayPos.y);
			Vector4 b = new Vector4(drawData.FramebufferScale.x, drawData.FramebufferScale.y, drawData.FramebufferScale.x, drawData.FramebufferScale.y);
			_material.SetBuffer(_verticesID, _vertexBuffer);
			cmd.SetViewport(new Rect(0f, 0f, fbSize.x, fbSize.y));
			cmd.SetViewProjectionMatrices(Matrix4x4.Translate(new Vector3(0.5f / fbSize.x, 0.5f / fbSize.y, 0f)), Matrix4x4.Ortho(0f, fbSize.x, fbSize.y, 0f, 0f, 1f));
			int num = 0;
			int num2 = 0;
			int i = 0;
			for (int cmdListsCount = drawData.CmdListsCount; i < cmdListsCount; i++)
			{
				ImDrawListPtr parent_list = drawData.CmdListsRange[i];
				int num3 = 0;
				int size = parent_list.CmdBuffer.Size;
				while (num3 < size)
				{
					ImDrawCmdPtr cmd2 = parent_list.CmdBuffer[num3];
					if (cmd2.UserCallback != IntPtr.Zero)
					{
						Marshal.GetDelegateForFunctionPointer<UserDrawCallback>(cmd2.UserCallback)(parent_list, cmd2);
					}
					else
					{
						Vector4 vector2 = Vector4.Scale(cmd2.ClipRect - vector, b);
						if (!(vector2.x >= fbSize.x) && !(vector2.y >= fbSize.y) && !(vector2.z < 0f) && !(vector2.w < 0f))
						{
							if (intPtr != cmd2.TextureId)
							{
								intPtr = cmd2.TextureId;
								_textureManager.TryGetTexture(intPtr, out var texture);
								_materialProperties.SetTexture(_textureID, texture);
							}
							_materialProperties.SetInt(_baseVertexID, num + (int)cmd2.VtxOffset);
							cmd.EnableScissorRect(new Rect(vector2.x, fbSize.y - vector2.w, vector2.z - vector2.x, vector2.w - vector2.y));
							cmd.DrawProceduralIndirect(_indexBuffer, Matrix4x4.identity, _material, -1, MeshTopology.Triangles, _argumentsBuffer, num2, _materialProperties);
						}
					}
					num3++;
					num2 += 20;
				}
				num += parent_list.VtxBuffer.Size;
			}
			cmd.DisableScissorRect();
		}
	}
}
