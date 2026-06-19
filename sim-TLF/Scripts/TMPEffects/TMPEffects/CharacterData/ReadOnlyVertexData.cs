using System;
using TMPro;
using UnityEngine;

namespace TMPEffects.CharacterData
{
	public class ReadOnlyVertexData
	{
		private TMP_Vertex vertex_BL;

		private TMP_Vertex vertex_TL;

		private TMP_Vertex vertex_TR;

		private TMP_Vertex vertex_BR;

		public Color32 BL_Color => vertex_BL.color;

		public Color32 TL_Color => vertex_TL.color;

		public Color32 TR_Color => vertex_TR.color;

		public Color32 BR_Color => vertex_BR.color;

		public byte BL_Alpha => vertex_BL.color.a;

		public byte TL_Alpha => vertex_TL.color.a;

		public byte TR_Alpha => vertex_TR.color.a;

		public byte BR_Alpha => vertex_BR.color.a;

		public Vector3 BL_Position => vertex_BL.position;

		public Vector3 TL_Position => vertex_TL.position;

		public Vector3 TR_Position => vertex_TR.position;

		public Vector3 BR_Position => vertex_BR.position;

		public Vector3 BL_UV0 => vertex_BL.uv;

		public Vector3 TL_UV0 => vertex_TL.uv;

		public Vector3 TR_UV0 => vertex_TR.uv;

		public Vector3 BR_UV0 => vertex_BR.uv;

		public Vector3 BL_UV2 => vertex_BL.uv2;

		public Vector3 TL_UV2 => vertex_TL.uv2;

		public Vector3 TR_UV2 => vertex_TR.uv2;

		public Vector3 BR_UV2 => vertex_BR.uv2;

		public ReadOnlyVertexData(TMP_Vertex bl, TMP_Vertex tl, TMP_Vertex tr, TMP_Vertex br)
		{
			vertex_BL = bl;
			vertex_TL = tl;
			vertex_TR = tr;
			vertex_BR = br;
		}

		public ReadOnlyVertexData(TMP_CharacterInfo info)
		{
			vertex_BL = info.vertex_BL;
			vertex_TL = info.vertex_TL;
			vertex_TR = info.vertex_TR;
			vertex_BR = info.vertex_BR;
		}

		public Vector3 GetPosition(int i)
		{
			return i switch
			{
				0 => vertex_BL.position, 
				1 => vertex_TL.position, 
				2 => vertex_TR.position, 
				3 => vertex_BR.position, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public Color32 GetColor(int i)
		{
			return i switch
			{
				0 => vertex_BL.color, 
				1 => vertex_TL.color, 
				2 => vertex_TR.color, 
				3 => vertex_BR.color, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public byte GetAlpha(int i)
		{
			return i switch
			{
				0 => vertex_BL.color.a, 
				1 => vertex_TL.color.a, 
				2 => vertex_TR.color.a, 
				3 => vertex_BR.color.a, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public Vector2 GetUV0(int i)
		{
			return i switch
			{
				0 => vertex_BL.uv, 
				1 => vertex_TL.uv, 
				2 => vertex_TR.uv, 
				3 => vertex_BR.uv, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public Vector2 GetUV2(int i)
		{
			return i switch
			{
				0 => vertex_BL.uv2, 
				1 => vertex_TL.uv2, 
				2 => vertex_TR.uv2, 
				3 => vertex_BR.uv2, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}
