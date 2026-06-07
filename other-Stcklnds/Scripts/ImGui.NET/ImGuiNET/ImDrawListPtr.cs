using System;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace ImGuiNET
{
	public struct ImDrawListPtr
	{
		public unsafe ImDrawList* NativePtr { get; }

		public unsafe ImPtrVector<ImDrawCmdPtr> CmdBuffer => new ImPtrVector<ImDrawCmdPtr>(NativePtr->CmdBuffer, Unsafe.SizeOf<ImDrawCmd>());

		public unsafe ImVector<ushort> IdxBuffer => new ImVector<ushort>(NativePtr->IdxBuffer);

		public unsafe ImPtrVector<ImDrawVertPtr> VtxBuffer => new ImPtrVector<ImDrawVertPtr>(NativePtr->VtxBuffer, Unsafe.SizeOf<ImDrawVert>());

		public unsafe ref ImDrawListFlags Flags => ref Unsafe.AsRef<ImDrawListFlags>(&NativePtr->Flags);

		public unsafe ref uint _VtxCurrentIdx => ref Unsafe.AsRef<uint>(&NativePtr->_VtxCurrentIdx);

		public unsafe ref IntPtr _Data => ref Unsafe.AsRef<IntPtr>(&NativePtr->_Data);

		public unsafe NullTerminatedString _OwnerName => new NullTerminatedString(NativePtr->_OwnerName);

		public unsafe ImDrawVertPtr _VtxWritePtr => new ImDrawVertPtr(NativePtr->_VtxWritePtr);

		public unsafe IntPtr _IdxWritePtr
		{
			get
			{
				return (IntPtr)NativePtr->_IdxWritePtr;
			}
			set
			{
				NativePtr->_IdxWritePtr = (ushort*)(void*)value;
			}
		}

		public unsafe ImVector<Vector4> _ClipRectStack => new ImVector<Vector4>(NativePtr->_ClipRectStack);

		public unsafe ImVector<IntPtr> _TextureIdStack => new ImVector<IntPtr>(NativePtr->_TextureIdStack);

		public unsafe ImVector<Vector2> _Path => new ImVector<Vector2>(NativePtr->_Path);

		public unsafe ref ImDrawCmdHeader _CmdHeader => ref Unsafe.AsRef<ImDrawCmdHeader>(&NativePtr->_CmdHeader);

		public unsafe ref ImDrawListSplitter _Splitter => ref Unsafe.AsRef<ImDrawListSplitter>(&NativePtr->_Splitter);

		public unsafe ref float _FringeScale => ref Unsafe.AsRef<float>(&NativePtr->_FringeScale);

		public unsafe ImDrawListPtr(ImDrawList* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImDrawListPtr(IntPtr nativePtr)
		{
			NativePtr = (ImDrawList*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImDrawListPtr(ImDrawList* nativePtr)
		{
			return new ImDrawListPtr(nativePtr);
		}

		public unsafe static implicit operator ImDrawList*(ImDrawListPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImDrawListPtr(IntPtr nativePtr)
		{
			return new ImDrawListPtr(nativePtr);
		}

		public unsafe int _CalcCircleAutoSegmentCount(float radius)
		{
			return ImGuiNative.ImDrawList__CalcCircleAutoSegmentCount(NativePtr, radius);
		}

		public unsafe void _ClearFreeMemory()
		{
			ImGuiNative.ImDrawList__ClearFreeMemory(NativePtr);
		}

		public unsafe void _OnChangedClipRect()
		{
			ImGuiNative.ImDrawList__OnChangedClipRect(NativePtr);
		}

		public unsafe void _OnChangedTextureID()
		{
			ImGuiNative.ImDrawList__OnChangedTextureID(NativePtr);
		}

		public unsafe void _OnChangedVtxOffset()
		{
			ImGuiNative.ImDrawList__OnChangedVtxOffset(NativePtr);
		}

		public unsafe void _PathArcToFastEx(Vector2 center, float radius, int a_min_sample, int a_max_sample, int a_step)
		{
			ImGuiNative.ImDrawList__PathArcToFastEx(NativePtr, center, radius, a_min_sample, a_max_sample, a_step);
		}

		public unsafe void _PathArcToN(Vector2 center, float radius, float a_min, float a_max, int num_segments)
		{
			ImGuiNative.ImDrawList__PathArcToN(NativePtr, center, radius, a_min, a_max, num_segments);
		}

		public unsafe void _PopUnusedDrawCmd()
		{
			ImGuiNative.ImDrawList__PopUnusedDrawCmd(NativePtr);
		}

		public unsafe void _ResetForNewFrame()
		{
			ImGuiNative.ImDrawList__ResetForNewFrame(NativePtr);
		}

		public unsafe void _TryMergeDrawCmds()
		{
			ImGuiNative.ImDrawList__TryMergeDrawCmds(NativePtr);
		}

		public unsafe void AddBezierCubic(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col, float thickness)
		{
			int num_segments = 0;
			ImGuiNative.ImDrawList_AddBezierCubic(NativePtr, p1, p2, p3, p4, col, thickness, num_segments);
		}

		public unsafe void AddBezierCubic(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col, float thickness, int num_segments)
		{
			ImGuiNative.ImDrawList_AddBezierCubic(NativePtr, p1, p2, p3, p4, col, thickness, num_segments);
		}

		public unsafe void AddBezierQuadratic(Vector2 p1, Vector2 p2, Vector2 p3, uint col, float thickness)
		{
			int num_segments = 0;
			ImGuiNative.ImDrawList_AddBezierQuadratic(NativePtr, p1, p2, p3, col, thickness, num_segments);
		}

		public unsafe void AddBezierQuadratic(Vector2 p1, Vector2 p2, Vector2 p3, uint col, float thickness, int num_segments)
		{
			ImGuiNative.ImDrawList_AddBezierQuadratic(NativePtr, p1, p2, p3, col, thickness, num_segments);
		}

		public unsafe void AddCallback(IntPtr callback, IntPtr callback_data)
		{
			void* callback_data2 = callback_data.ToPointer();
			ImGuiNative.ImDrawList_AddCallback(NativePtr, callback, callback_data2);
		}

		public unsafe void AddCircle(Vector2 center, float radius, uint col)
		{
			int num_segments = 0;
			float thickness = 1f;
			ImGuiNative.ImDrawList_AddCircle(NativePtr, center, radius, col, num_segments, thickness);
		}

		public unsafe void AddCircle(Vector2 center, float radius, uint col, int num_segments)
		{
			float thickness = 1f;
			ImGuiNative.ImDrawList_AddCircle(NativePtr, center, radius, col, num_segments, thickness);
		}

		public unsafe void AddCircle(Vector2 center, float radius, uint col, int num_segments, float thickness)
		{
			ImGuiNative.ImDrawList_AddCircle(NativePtr, center, radius, col, num_segments, thickness);
		}

		public unsafe void AddCircleFilled(Vector2 center, float radius, uint col)
		{
			int num_segments = 0;
			ImGuiNative.ImDrawList_AddCircleFilled(NativePtr, center, radius, col, num_segments);
		}

		public unsafe void AddCircleFilled(Vector2 center, float radius, uint col, int num_segments)
		{
			ImGuiNative.ImDrawList_AddCircleFilled(NativePtr, center, radius, col, num_segments);
		}

		public unsafe void AddConvexPolyFilled(ref Vector2 points, int num_points, uint col)
		{
			fixed (Vector2* points2 = &points)
			{
				ImGuiNative.ImDrawList_AddConvexPolyFilled(NativePtr, points2, num_points, col);
			}
		}

		public unsafe void AddDrawCmd()
		{
			ImGuiNative.ImDrawList_AddDrawCmd(NativePtr);
		}

		public unsafe void AddImage(IntPtr user_texture_id, Vector2 p_min, Vector2 p_max)
		{
			Vector2 uv_min = default(Vector2);
			Vector2 uv_max = new Vector2(1f, 1f);
			uint col = uint.MaxValue;
			ImGuiNative.ImDrawList_AddImage(NativePtr, user_texture_id, p_min, p_max, uv_min, uv_max, col);
		}

		public unsafe void AddImage(IntPtr user_texture_id, Vector2 p_min, Vector2 p_max, Vector2 uv_min)
		{
			Vector2 uv_max = new Vector2(1f, 1f);
			uint col = uint.MaxValue;
			ImGuiNative.ImDrawList_AddImage(NativePtr, user_texture_id, p_min, p_max, uv_min, uv_max, col);
		}

		public unsafe void AddImage(IntPtr user_texture_id, Vector2 p_min, Vector2 p_max, Vector2 uv_min, Vector2 uv_max)
		{
			uint col = uint.MaxValue;
			ImGuiNative.ImDrawList_AddImage(NativePtr, user_texture_id, p_min, p_max, uv_min, uv_max, col);
		}

		public unsafe void AddImage(IntPtr user_texture_id, Vector2 p_min, Vector2 p_max, Vector2 uv_min, Vector2 uv_max, uint col)
		{
			ImGuiNative.ImDrawList_AddImage(NativePtr, user_texture_id, p_min, p_max, uv_min, uv_max, col);
		}

		public unsafe void AddImageQuad(IntPtr user_texture_id, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
		{
			Vector2 uv = default(Vector2);
			Vector2 uv2 = new Vector2(1f, 0f);
			Vector2 uv3 = new Vector2(1f, 1f);
			Vector2 uv4 = new Vector2(0f, 1f);
			uint col = uint.MaxValue;
			ImGuiNative.ImDrawList_AddImageQuad(NativePtr, user_texture_id, p1, p2, p3, p4, uv, uv2, uv3, uv4, col);
		}

		public unsafe void AddImageQuad(IntPtr user_texture_id, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1)
		{
			Vector2 uv2 = new Vector2(1f, 0f);
			Vector2 uv3 = new Vector2(1f, 1f);
			Vector2 uv4 = new Vector2(0f, 1f);
			uint col = uint.MaxValue;
			ImGuiNative.ImDrawList_AddImageQuad(NativePtr, user_texture_id, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
		}

		public unsafe void AddImageQuad(IntPtr user_texture_id, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1, Vector2 uv2)
		{
			Vector2 uv3 = new Vector2(1f, 1f);
			Vector2 uv4 = new Vector2(0f, 1f);
			uint col = uint.MaxValue;
			ImGuiNative.ImDrawList_AddImageQuad(NativePtr, user_texture_id, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
		}

		public unsafe void AddImageQuad(IntPtr user_texture_id, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1, Vector2 uv2, Vector2 uv3)
		{
			Vector2 uv4 = new Vector2(0f, 1f);
			uint col = uint.MaxValue;
			ImGuiNative.ImDrawList_AddImageQuad(NativePtr, user_texture_id, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
		}

		public unsafe void AddImageQuad(IntPtr user_texture_id, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1, Vector2 uv2, Vector2 uv3, Vector2 uv4)
		{
			uint col = uint.MaxValue;
			ImGuiNative.ImDrawList_AddImageQuad(NativePtr, user_texture_id, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
		}

		public unsafe void AddImageQuad(IntPtr user_texture_id, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1, Vector2 uv2, Vector2 uv3, Vector2 uv4, uint col)
		{
			ImGuiNative.ImDrawList_AddImageQuad(NativePtr, user_texture_id, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
		}

		public unsafe void AddImageRounded(IntPtr user_texture_id, Vector2 p_min, Vector2 p_max, Vector2 uv_min, Vector2 uv_max, uint col, float rounding)
		{
			ImDrawFlags flags = ImDrawFlags.None;
			ImGuiNative.ImDrawList_AddImageRounded(NativePtr, user_texture_id, p_min, p_max, uv_min, uv_max, col, rounding, flags);
		}

		public unsafe void AddImageRounded(IntPtr user_texture_id, Vector2 p_min, Vector2 p_max, Vector2 uv_min, Vector2 uv_max, uint col, float rounding, ImDrawFlags flags)
		{
			ImGuiNative.ImDrawList_AddImageRounded(NativePtr, user_texture_id, p_min, p_max, uv_min, uv_max, col, rounding, flags);
		}

		public unsafe void AddLine(Vector2 p1, Vector2 p2, uint col)
		{
			float thickness = 1f;
			ImGuiNative.ImDrawList_AddLine(NativePtr, p1, p2, col, thickness);
		}

		public unsafe void AddLine(Vector2 p1, Vector2 p2, uint col, float thickness)
		{
			ImGuiNative.ImDrawList_AddLine(NativePtr, p1, p2, col, thickness);
		}

		public unsafe void AddNgon(Vector2 center, float radius, uint col, int num_segments)
		{
			float thickness = 1f;
			ImGuiNative.ImDrawList_AddNgon(NativePtr, center, radius, col, num_segments, thickness);
		}

		public unsafe void AddNgon(Vector2 center, float radius, uint col, int num_segments, float thickness)
		{
			ImGuiNative.ImDrawList_AddNgon(NativePtr, center, radius, col, num_segments, thickness);
		}

		public unsafe void AddNgonFilled(Vector2 center, float radius, uint col, int num_segments)
		{
			ImGuiNative.ImDrawList_AddNgonFilled(NativePtr, center, radius, col, num_segments);
		}

		public unsafe void AddPolyline(ref Vector2 points, int num_points, uint col, ImDrawFlags flags, float thickness)
		{
			fixed (Vector2* points2 = &points)
			{
				ImGuiNative.ImDrawList_AddPolyline(NativePtr, points2, num_points, col, flags, thickness);
			}
		}

		public unsafe void AddQuad(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col)
		{
			float thickness = 1f;
			ImGuiNative.ImDrawList_AddQuad(NativePtr, p1, p2, p3, p4, col, thickness);
		}

		public unsafe void AddQuad(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col, float thickness)
		{
			ImGuiNative.ImDrawList_AddQuad(NativePtr, p1, p2, p3, p4, col, thickness);
		}

		public unsafe void AddQuadFilled(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col)
		{
			ImGuiNative.ImDrawList_AddQuadFilled(NativePtr, p1, p2, p3, p4, col);
		}

		public unsafe void AddRect(Vector2 p_min, Vector2 p_max, uint col)
		{
			float rounding = 0f;
			ImDrawFlags flags = ImDrawFlags.None;
			float thickness = 1f;
			ImGuiNative.ImDrawList_AddRect(NativePtr, p_min, p_max, col, rounding, flags, thickness);
		}

		public unsafe void AddRect(Vector2 p_min, Vector2 p_max, uint col, float rounding)
		{
			ImDrawFlags flags = ImDrawFlags.None;
			float thickness = 1f;
			ImGuiNative.ImDrawList_AddRect(NativePtr, p_min, p_max, col, rounding, flags, thickness);
		}

		public unsafe void AddRect(Vector2 p_min, Vector2 p_max, uint col, float rounding, ImDrawFlags flags)
		{
			float thickness = 1f;
			ImGuiNative.ImDrawList_AddRect(NativePtr, p_min, p_max, col, rounding, flags, thickness);
		}

		public unsafe void AddRect(Vector2 p_min, Vector2 p_max, uint col, float rounding, ImDrawFlags flags, float thickness)
		{
			ImGuiNative.ImDrawList_AddRect(NativePtr, p_min, p_max, col, rounding, flags, thickness);
		}

		public unsafe void AddRectFilled(Vector2 p_min, Vector2 p_max, uint col)
		{
			float rounding = 0f;
			ImDrawFlags flags = ImDrawFlags.None;
			ImGuiNative.ImDrawList_AddRectFilled(NativePtr, p_min, p_max, col, rounding, flags);
		}

		public unsafe void AddRectFilled(Vector2 p_min, Vector2 p_max, uint col, float rounding)
		{
			ImDrawFlags flags = ImDrawFlags.None;
			ImGuiNative.ImDrawList_AddRectFilled(NativePtr, p_min, p_max, col, rounding, flags);
		}

		public unsafe void AddRectFilled(Vector2 p_min, Vector2 p_max, uint col, float rounding, ImDrawFlags flags)
		{
			ImGuiNative.ImDrawList_AddRectFilled(NativePtr, p_min, p_max, col, rounding, flags);
		}

		public unsafe void AddRectFilledMultiColor(Vector2 p_min, Vector2 p_max, uint col_upr_left, uint col_upr_right, uint col_bot_right, uint col_bot_left)
		{
			ImGuiNative.ImDrawList_AddRectFilledMultiColor(NativePtr, p_min, p_max, col_upr_left, col_upr_right, col_bot_right, col_bot_left);
		}

		public unsafe void AddTriangle(Vector2 p1, Vector2 p2, Vector2 p3, uint col)
		{
			float thickness = 1f;
			ImGuiNative.ImDrawList_AddTriangle(NativePtr, p1, p2, p3, col, thickness);
		}

		public unsafe void AddTriangle(Vector2 p1, Vector2 p2, Vector2 p3, uint col, float thickness)
		{
			ImGuiNative.ImDrawList_AddTriangle(NativePtr, p1, p2, p3, col, thickness);
		}

		public unsafe void AddTriangleFilled(Vector2 p1, Vector2 p2, Vector2 p3, uint col)
		{
			ImGuiNative.ImDrawList_AddTriangleFilled(NativePtr, p1, p2, p3, col);
		}

		public unsafe void ChannelsMerge()
		{
			ImGuiNative.ImDrawList_ChannelsMerge(NativePtr);
		}

		public unsafe void ChannelsSetCurrent(int n)
		{
			ImGuiNative.ImDrawList_ChannelsSetCurrent(NativePtr, n);
		}

		public unsafe void ChannelsSplit(int count)
		{
			ImGuiNative.ImDrawList_ChannelsSplit(NativePtr, count);
		}

		public unsafe ImDrawListPtr CloneOutput()
		{
			return new ImDrawListPtr(ImGuiNative.ImDrawList_CloneOutput(NativePtr));
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImDrawList_destroy(NativePtr);
		}

		public unsafe Vector2 GetClipRectMax()
		{
			Vector2 result = default(Vector2);
			ImGuiNative.ImDrawList_GetClipRectMax(&result, NativePtr);
			return result;
		}

		public unsafe Vector2 GetClipRectMin()
		{
			Vector2 result = default(Vector2);
			ImGuiNative.ImDrawList_GetClipRectMin(&result, NativePtr);
			return result;
		}

		public unsafe void PathArcTo(Vector2 center, float radius, float a_min, float a_max)
		{
			int num_segments = 0;
			ImGuiNative.ImDrawList_PathArcTo(NativePtr, center, radius, a_min, a_max, num_segments);
		}

		public unsafe void PathArcTo(Vector2 center, float radius, float a_min, float a_max, int num_segments)
		{
			ImGuiNative.ImDrawList_PathArcTo(NativePtr, center, radius, a_min, a_max, num_segments);
		}

		public unsafe void PathArcToFast(Vector2 center, float radius, int a_min_of_12, int a_max_of_12)
		{
			ImGuiNative.ImDrawList_PathArcToFast(NativePtr, center, radius, a_min_of_12, a_max_of_12);
		}

		public unsafe void PathBezierCubicCurveTo(Vector2 p2, Vector2 p3, Vector2 p4)
		{
			int num_segments = 0;
			ImGuiNative.ImDrawList_PathBezierCubicCurveTo(NativePtr, p2, p3, p4, num_segments);
		}

		public unsafe void PathBezierCubicCurveTo(Vector2 p2, Vector2 p3, Vector2 p4, int num_segments)
		{
			ImGuiNative.ImDrawList_PathBezierCubicCurveTo(NativePtr, p2, p3, p4, num_segments);
		}

		public unsafe void PathBezierQuadraticCurveTo(Vector2 p2, Vector2 p3)
		{
			int num_segments = 0;
			ImGuiNative.ImDrawList_PathBezierQuadraticCurveTo(NativePtr, p2, p3, num_segments);
		}

		public unsafe void PathBezierQuadraticCurveTo(Vector2 p2, Vector2 p3, int num_segments)
		{
			ImGuiNative.ImDrawList_PathBezierQuadraticCurveTo(NativePtr, p2, p3, num_segments);
		}

		public unsafe void PathClear()
		{
			ImGuiNative.ImDrawList_PathClear(NativePtr);
		}

		public unsafe void PathFillConvex(uint col)
		{
			ImGuiNative.ImDrawList_PathFillConvex(NativePtr, col);
		}

		public unsafe void PathLineTo(Vector2 pos)
		{
			ImGuiNative.ImDrawList_PathLineTo(NativePtr, pos);
		}

		public unsafe void PathLineToMergeDuplicate(Vector2 pos)
		{
			ImGuiNative.ImDrawList_PathLineToMergeDuplicate(NativePtr, pos);
		}

		public unsafe void PathRect(Vector2 rect_min, Vector2 rect_max)
		{
			float rounding = 0f;
			ImDrawFlags flags = ImDrawFlags.None;
			ImGuiNative.ImDrawList_PathRect(NativePtr, rect_min, rect_max, rounding, flags);
		}

		public unsafe void PathRect(Vector2 rect_min, Vector2 rect_max, float rounding)
		{
			ImDrawFlags flags = ImDrawFlags.None;
			ImGuiNative.ImDrawList_PathRect(NativePtr, rect_min, rect_max, rounding, flags);
		}

		public unsafe void PathRect(Vector2 rect_min, Vector2 rect_max, float rounding, ImDrawFlags flags)
		{
			ImGuiNative.ImDrawList_PathRect(NativePtr, rect_min, rect_max, rounding, flags);
		}

		public unsafe void PathStroke(uint col)
		{
			ImDrawFlags flags = ImDrawFlags.None;
			float thickness = 1f;
			ImGuiNative.ImDrawList_PathStroke(NativePtr, col, flags, thickness);
		}

		public unsafe void PathStroke(uint col, ImDrawFlags flags)
		{
			float thickness = 1f;
			ImGuiNative.ImDrawList_PathStroke(NativePtr, col, flags, thickness);
		}

		public unsafe void PathStroke(uint col, ImDrawFlags flags, float thickness)
		{
			ImGuiNative.ImDrawList_PathStroke(NativePtr, col, flags, thickness);
		}

		public unsafe void PopClipRect()
		{
			ImGuiNative.ImDrawList_PopClipRect(NativePtr);
		}

		public unsafe void PopTextureID()
		{
			ImGuiNative.ImDrawList_PopTextureID(NativePtr);
		}

		public unsafe void PrimQuadUV(Vector2 a, Vector2 b, Vector2 c, Vector2 d, Vector2 uv_a, Vector2 uv_b, Vector2 uv_c, Vector2 uv_d, uint col)
		{
			ImGuiNative.ImDrawList_PrimQuadUV(NativePtr, a, b, c, d, uv_a, uv_b, uv_c, uv_d, col);
		}

		public unsafe void PrimRect(Vector2 a, Vector2 b, uint col)
		{
			ImGuiNative.ImDrawList_PrimRect(NativePtr, a, b, col);
		}

		public unsafe void PrimRectUV(Vector2 a, Vector2 b, Vector2 uv_a, Vector2 uv_b, uint col)
		{
			ImGuiNative.ImDrawList_PrimRectUV(NativePtr, a, b, uv_a, uv_b, col);
		}

		public unsafe void PrimReserve(int idx_count, int vtx_count)
		{
			ImGuiNative.ImDrawList_PrimReserve(NativePtr, idx_count, vtx_count);
		}

		public unsafe void PrimUnreserve(int idx_count, int vtx_count)
		{
			ImGuiNative.ImDrawList_PrimUnreserve(NativePtr, idx_count, vtx_count);
		}

		public unsafe void PrimVtx(Vector2 pos, Vector2 uv, uint col)
		{
			ImGuiNative.ImDrawList_PrimVtx(NativePtr, pos, uv, col);
		}

		public unsafe void PrimWriteIdx(ushort idx)
		{
			ImGuiNative.ImDrawList_PrimWriteIdx(NativePtr, idx);
		}

		public unsafe void PrimWriteVtx(Vector2 pos, Vector2 uv, uint col)
		{
			ImGuiNative.ImDrawList_PrimWriteVtx(NativePtr, pos, uv, col);
		}

		public unsafe void PushClipRect(Vector2 clip_rect_min, Vector2 clip_rect_max)
		{
			byte intersect_with_current_clip_rect = 0;
			ImGuiNative.ImDrawList_PushClipRect(NativePtr, clip_rect_min, clip_rect_max, intersect_with_current_clip_rect);
		}

		public unsafe void PushClipRect(Vector2 clip_rect_min, Vector2 clip_rect_max, bool intersect_with_current_clip_rect)
		{
			byte intersect_with_current_clip_rect2 = (byte)(intersect_with_current_clip_rect ? 1 : 0);
			ImGuiNative.ImDrawList_PushClipRect(NativePtr, clip_rect_min, clip_rect_max, intersect_with_current_clip_rect2);
		}

		public unsafe void PushClipRectFullScreen()
		{
			ImGuiNative.ImDrawList_PushClipRectFullScreen(NativePtr);
		}

		public unsafe void PushTextureID(IntPtr texture_id)
		{
			ImGuiNative.ImDrawList_PushTextureID(NativePtr, texture_id);
		}

		public unsafe void AddText(Vector2 pos, uint col, string text_begin)
		{
			int byteCount = Encoding.UTF8.GetByteCount(text_begin);
			byte* ptr = stackalloc byte[(int)(uint)(byteCount + 1)];
			fixed (char* chars = text_begin)
			{
				int bytes = Encoding.UTF8.GetBytes(chars, text_begin.Length, ptr, byteCount);
				ptr[bytes] = 0;
			}
			byte* text_end = null;
			ImGuiNative.ImDrawList_AddText_Vec2(NativePtr, pos, col, ptr, text_end);
		}

		public unsafe void AddText(ImFontPtr font, float font_size, Vector2 pos, uint col, string text_begin)
		{
			ImFont* nativePtr = font.NativePtr;
			int byteCount = Encoding.UTF8.GetByteCount(text_begin);
			byte* ptr = stackalloc byte[(int)(uint)(byteCount + 1)];
			fixed (char* chars = text_begin)
			{
				int bytes = Encoding.UTF8.GetBytes(chars, text_begin.Length, ptr, byteCount);
				ptr[bytes] = 0;
			}
			byte* text_end = null;
			float wrap_width = 0f;
			Vector4* cpu_fine_clip_rect = null;
			ImGuiNative.ImDrawList_AddText_FontPtr(NativePtr, nativePtr, font_size, pos, col, ptr, text_end, wrap_width, cpu_fine_clip_rect);
		}
	}
}
