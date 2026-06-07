using System;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace ImGuiNET
{
	public static class ImGui
	{
		public unsafe static ImGuiPayloadPtr AcceptDragDropPayload(string type)
		{
			int num = 0;
			byte* ptr;
			if (type != null)
			{
				num = Encoding.UTF8.GetByteCount(type);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(type, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiDragDropFlags flags = ImGuiDragDropFlags.None;
			ImGuiPayload* nativePtr = ImGuiNative.igAcceptDragDropPayload(ptr, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return new ImGuiPayloadPtr(nativePtr);
		}

		public unsafe static ImGuiPayloadPtr AcceptDragDropPayload(string type, ImGuiDragDropFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (type != null)
			{
				num = Encoding.UTF8.GetByteCount(type);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(type, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiPayload* nativePtr = ImGuiNative.igAcceptDragDropPayload(ptr, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return new ImGuiPayloadPtr(nativePtr);
		}

		public static void AlignTextToFramePadding()
		{
			ImGuiNative.igAlignTextToFramePadding();
		}

		public unsafe static bool ArrowButton(string str_id, ImGuiDir dir)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igArrowButton(ptr, dir);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool Begin(string name)
		{
			int num = 0;
			byte* ptr;
			if (name != null)
			{
				num = Encoding.UTF8.GetByteCount(name);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(name, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte* p_open = null;
			ImGuiWindowFlags flags = ImGuiWindowFlags.None;
			byte num2 = ImGuiNative.igBegin(ptr, p_open, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool Begin(string name, ref bool p_open)
		{
			int num = 0;
			byte* ptr;
			if (name != null)
			{
				num = Encoding.UTF8.GetByteCount(name);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(name, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte b = (byte)(p_open ? 1 : 0);
			byte* p_open2 = &b;
			ImGuiWindowFlags flags = ImGuiWindowFlags.None;
			byte num2 = ImGuiNative.igBegin(ptr, p_open2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			p_open = b != 0;
			return num2 != 0;
		}

		public unsafe static bool Begin(string name, ref bool p_open, ImGuiWindowFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (name != null)
			{
				num = Encoding.UTF8.GetByteCount(name);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(name, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte b = (byte)(p_open ? 1 : 0);
			byte* p_open2 = &b;
			byte num2 = ImGuiNative.igBegin(ptr, p_open2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			p_open = b != 0;
			return num2 != 0;
		}

		public unsafe static bool BeginChild(string str_id)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			Vector2 size = default(Vector2);
			byte border = 0;
			ImGuiWindowFlags flags = ImGuiWindowFlags.None;
			byte num2 = ImGuiNative.igBeginChild_Str(ptr, size, border, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool BeginChild(string str_id, Vector2 size)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte border = 0;
			ImGuiWindowFlags flags = ImGuiWindowFlags.None;
			byte num2 = ImGuiNative.igBeginChild_Str(ptr, size, border, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool BeginChild(string str_id, Vector2 size, bool border)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte border2 = (byte)(border ? 1 : 0);
			ImGuiWindowFlags flags = ImGuiWindowFlags.None;
			byte num2 = ImGuiNative.igBeginChild_Str(ptr, size, border2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool BeginChild(string str_id, Vector2 size, bool border, ImGuiWindowFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte border2 = (byte)(border ? 1 : 0);
			byte num2 = ImGuiNative.igBeginChild_Str(ptr, size, border2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public static bool BeginChild(uint id)
		{
			Vector2 size = default(Vector2);
			byte border = 0;
			ImGuiWindowFlags flags = ImGuiWindowFlags.None;
			return ImGuiNative.igBeginChild_ID(id, size, border, flags) != 0;
		}

		public static bool BeginChild(uint id, Vector2 size)
		{
			byte border = 0;
			ImGuiWindowFlags flags = ImGuiWindowFlags.None;
			return ImGuiNative.igBeginChild_ID(id, size, border, flags) != 0;
		}

		public static bool BeginChild(uint id, Vector2 size, bool border)
		{
			byte border2 = (byte)(border ? 1 : 0);
			ImGuiWindowFlags flags = ImGuiWindowFlags.None;
			return ImGuiNative.igBeginChild_ID(id, size, border2, flags) != 0;
		}

		public static bool BeginChild(uint id, Vector2 size, bool border, ImGuiWindowFlags flags)
		{
			byte border2 = (byte)(border ? 1 : 0);
			return ImGuiNative.igBeginChild_ID(id, size, border2, flags) != 0;
		}

		public static bool BeginChildFrame(uint id, Vector2 size)
		{
			ImGuiWindowFlags flags = ImGuiWindowFlags.None;
			return ImGuiNative.igBeginChildFrame(id, size, flags) != 0;
		}

		public static bool BeginChildFrame(uint id, Vector2 size, ImGuiWindowFlags flags)
		{
			return ImGuiNative.igBeginChildFrame(id, size, flags) != 0;
		}

		public unsafe static bool BeginCombo(string label, string preview_value)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (preview_value != null)
			{
				num2 = Encoding.UTF8.GetByteCount(preview_value);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(preview_value, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiComboFlags flags = ImGuiComboFlags.None;
			byte num3 = ImGuiNative.igBeginCombo(ptr, ptr2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public unsafe static bool BeginCombo(string label, string preview_value, ImGuiComboFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (preview_value != null)
			{
				num2 = Encoding.UTF8.GetByteCount(preview_value);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(preview_value, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			byte num3 = ImGuiNative.igBeginCombo(ptr, ptr2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public static void BeginDisabled()
		{
			ImGuiNative.igBeginDisabled(1);
		}

		public static void BeginDisabled(bool disabled)
		{
			ImGuiNative.igBeginDisabled((byte)(disabled ? 1 : 0));
		}

		public static bool BeginDragDropSource()
		{
			return ImGuiNative.igBeginDragDropSource(ImGuiDragDropFlags.None) != 0;
		}

		public static bool BeginDragDropSource(ImGuiDragDropFlags flags)
		{
			return ImGuiNative.igBeginDragDropSource(flags) != 0;
		}

		public static bool BeginDragDropTarget()
		{
			return ImGuiNative.igBeginDragDropTarget() != 0;
		}

		public static void BeginGroup()
		{
			ImGuiNative.igBeginGroup();
		}

		public unsafe static bool BeginListBox(string label)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igBeginListBox(ptr, default(Vector2));
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool BeginListBox(string label, Vector2 size)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igBeginListBox(ptr, size);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public static bool BeginMainMenuBar()
		{
			return ImGuiNative.igBeginMainMenuBar() != 0;
		}

		public unsafe static bool BeginMenu(string label)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte enabled = 1;
			byte num2 = ImGuiNative.igBeginMenu(ptr, enabled);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool BeginMenu(string label, bool enabled)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte enabled2 = (byte)(enabled ? 1 : 0);
			byte num2 = ImGuiNative.igBeginMenu(ptr, enabled2);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public static bool BeginMenuBar()
		{
			return ImGuiNative.igBeginMenuBar() != 0;
		}

		public unsafe static bool BeginPopup(string str_id)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiWindowFlags flags = ImGuiWindowFlags.None;
			byte num2 = ImGuiNative.igBeginPopup(ptr, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool BeginPopup(string str_id, ImGuiWindowFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igBeginPopup(ptr, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool BeginPopupContextItem()
		{
			byte* str_id = null;
			ImGuiPopupFlags popup_flags = ImGuiPopupFlags.MouseButtonRight;
			return ImGuiNative.igBeginPopupContextItem(str_id, popup_flags) != 0;
		}

		public unsafe static bool BeginPopupContextItem(string str_id)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiPopupFlags popup_flags = ImGuiPopupFlags.MouseButtonRight;
			byte num2 = ImGuiNative.igBeginPopupContextItem(ptr, popup_flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool BeginPopupContextItem(string str_id, ImGuiPopupFlags popup_flags)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igBeginPopupContextItem(ptr, popup_flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool BeginPopupContextVoid()
		{
			byte* str_id = null;
			ImGuiPopupFlags popup_flags = ImGuiPopupFlags.MouseButtonRight;
			return ImGuiNative.igBeginPopupContextVoid(str_id, popup_flags) != 0;
		}

		public unsafe static bool BeginPopupContextVoid(string str_id)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiPopupFlags popup_flags = ImGuiPopupFlags.MouseButtonRight;
			byte num2 = ImGuiNative.igBeginPopupContextVoid(ptr, popup_flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool BeginPopupContextVoid(string str_id, ImGuiPopupFlags popup_flags)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igBeginPopupContextVoid(ptr, popup_flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool BeginPopupContextWindow()
		{
			byte* str_id = null;
			ImGuiPopupFlags popup_flags = ImGuiPopupFlags.MouseButtonRight;
			return ImGuiNative.igBeginPopupContextWindow(str_id, popup_flags) != 0;
		}

		public unsafe static bool BeginPopupContextWindow(string str_id)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiPopupFlags popup_flags = ImGuiPopupFlags.MouseButtonRight;
			byte num2 = ImGuiNative.igBeginPopupContextWindow(ptr, popup_flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool BeginPopupContextWindow(string str_id, ImGuiPopupFlags popup_flags)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igBeginPopupContextWindow(ptr, popup_flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool BeginPopupModal(string name)
		{
			int num = 0;
			byte* ptr;
			if (name != null)
			{
				num = Encoding.UTF8.GetByteCount(name);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(name, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte* p_open = null;
			ImGuiWindowFlags flags = ImGuiWindowFlags.None;
			byte num2 = ImGuiNative.igBeginPopupModal(ptr, p_open, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool BeginPopupModal(string name, ref bool p_open)
		{
			int num = 0;
			byte* ptr;
			if (name != null)
			{
				num = Encoding.UTF8.GetByteCount(name);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(name, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte b = (byte)(p_open ? 1 : 0);
			byte* p_open2 = &b;
			ImGuiWindowFlags flags = ImGuiWindowFlags.None;
			byte num2 = ImGuiNative.igBeginPopupModal(ptr, p_open2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			p_open = b != 0;
			return num2 != 0;
		}

		public unsafe static bool BeginPopupModal(string name, ref bool p_open, ImGuiWindowFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (name != null)
			{
				num = Encoding.UTF8.GetByteCount(name);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(name, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte b = (byte)(p_open ? 1 : 0);
			byte* p_open2 = &b;
			byte num2 = ImGuiNative.igBeginPopupModal(ptr, p_open2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			p_open = b != 0;
			return num2 != 0;
		}

		public unsafe static bool BeginTabBar(string str_id)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiTabBarFlags flags = ImGuiTabBarFlags.None;
			byte num2 = ImGuiNative.igBeginTabBar(ptr, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool BeginTabBar(string str_id, ImGuiTabBarFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igBeginTabBar(ptr, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool BeginTabItem(string label)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte* p_open = null;
			ImGuiTabItemFlags flags = ImGuiTabItemFlags.None;
			byte num2 = ImGuiNative.igBeginTabItem(ptr, p_open, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool BeginTabItem(string label, ref bool p_open)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte b = (byte)(p_open ? 1 : 0);
			byte* p_open2 = &b;
			ImGuiTabItemFlags flags = ImGuiTabItemFlags.None;
			byte num2 = ImGuiNative.igBeginTabItem(ptr, p_open2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			p_open = b != 0;
			return num2 != 0;
		}

		public unsafe static bool BeginTabItem(string label, ref bool p_open, ImGuiTabItemFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte b = (byte)(p_open ? 1 : 0);
			byte* p_open2 = &b;
			byte num2 = ImGuiNative.igBeginTabItem(ptr, p_open2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			p_open = b != 0;
			return num2 != 0;
		}

		public unsafe static bool BeginTable(string str_id, int column)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiTableFlags flags = ImGuiTableFlags.None;
			Vector2 outer_size = default(Vector2);
			float inner_width = 0f;
			byte num2 = ImGuiNative.igBeginTable(ptr, column, flags, outer_size, inner_width);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool BeginTable(string str_id, int column, ImGuiTableFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			Vector2 outer_size = default(Vector2);
			float inner_width = 0f;
			byte num2 = ImGuiNative.igBeginTable(ptr, column, flags, outer_size, inner_width);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool BeginTable(string str_id, int column, ImGuiTableFlags flags, Vector2 outer_size)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float inner_width = 0f;
			byte num2 = ImGuiNative.igBeginTable(ptr, column, flags, outer_size, inner_width);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool BeginTable(string str_id, int column, ImGuiTableFlags flags, Vector2 outer_size, float inner_width)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igBeginTable(ptr, column, flags, outer_size, inner_width);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public static void BeginTooltip()
		{
			ImGuiNative.igBeginTooltip();
		}

		public static void Bullet()
		{
			ImGuiNative.igBullet();
		}

		public unsafe static void BulletText(string fmt)
		{
			int num = 0;
			byte* ptr;
			if (fmt != null)
			{
				num = Encoding.UTF8.GetByteCount(fmt);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(fmt, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igBulletText(ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static bool Button(string label)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igButton(ptr, default(Vector2));
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool Button(string label, Vector2 size)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igButton(ptr, size);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public static float CalcItemWidth()
		{
			return ImGuiNative.igCalcItemWidth();
		}

		public unsafe static bool Checkbox(string label, ref bool v)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte b = (byte)(v ? 1 : 0);
			byte* v2 = &b;
			byte num2 = ImGuiNative.igCheckbox(ptr, v2);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			v = b != 0;
			return num2 != 0;
		}

		public unsafe static bool CheckboxFlags(string label, ref int flags, int flags_value)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			fixed (int* flags2 = &flags)
			{
				byte num2 = ImGuiNative.igCheckboxFlags_IntPtr(ptr, flags2, flags_value);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public unsafe static bool CheckboxFlags(string label, ref uint flags, uint flags_value)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			fixed (uint* flags2 = &flags)
			{
				byte num2 = ImGuiNative.igCheckboxFlags_UintPtr(ptr, flags2, flags_value);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public static void CloseCurrentPopup()
		{
			ImGuiNative.igCloseCurrentPopup();
		}

		public unsafe static bool CollapsingHeader(string label)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiTreeNodeFlags flags = ImGuiTreeNodeFlags.None;
			byte num2 = ImGuiNative.igCollapsingHeader_TreeNodeFlags(ptr, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool CollapsingHeader(string label, ImGuiTreeNodeFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igCollapsingHeader_TreeNodeFlags(ptr, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool CollapsingHeader(string label, ref bool p_visible)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte b = (byte)(p_visible ? 1 : 0);
			byte* p_visible2 = &b;
			ImGuiTreeNodeFlags flags = ImGuiTreeNodeFlags.None;
			byte num2 = ImGuiNative.igCollapsingHeader_BoolPtr(ptr, p_visible2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			p_visible = b != 0;
			return num2 != 0;
		}

		public unsafe static bool CollapsingHeader(string label, ref bool p_visible, ImGuiTreeNodeFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte b = (byte)(p_visible ? 1 : 0);
			byte* p_visible2 = &b;
			byte num2 = ImGuiNative.igCollapsingHeader_BoolPtr(ptr, p_visible2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			p_visible = b != 0;
			return num2 != 0;
		}

		public unsafe static bool ColorButton(string desc_id, Vector4 col)
		{
			int num = 0;
			byte* ptr;
			if (desc_id != null)
			{
				num = Encoding.UTF8.GetByteCount(desc_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(desc_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiColorEditFlags flags = ImGuiColorEditFlags.None;
			byte num2 = ImGuiNative.igColorButton(ptr, col, flags, default(Vector2));
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool ColorButton(string desc_id, Vector4 col, ImGuiColorEditFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (desc_id != null)
			{
				num = Encoding.UTF8.GetByteCount(desc_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(desc_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igColorButton(ptr, col, flags, default(Vector2));
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool ColorButton(string desc_id, Vector4 col, ImGuiColorEditFlags flags, Vector2 size)
		{
			int num = 0;
			byte* ptr;
			if (desc_id != null)
			{
				num = Encoding.UTF8.GetByteCount(desc_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(desc_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igColorButton(ptr, col, flags, size);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public static uint ColorConvertFloat4ToU32(Vector4 @in)
		{
			return ImGuiNative.igColorConvertFloat4ToU32(@in);
		}

		public unsafe static void ColorConvertHSVtoRGB(float h, float s, float v, out float out_r, out float out_g, out float out_b)
		{
			fixed (float* out_r2 = &out_r)
			{
				fixed (float* out_g2 = &out_g)
				{
					fixed (float* out_b2 = &out_b)
					{
						ImGuiNative.igColorConvertHSVtoRGB(h, s, v, out_r2, out_g2, out_b2);
					}
				}
			}
		}

		public unsafe static void ColorConvertRGBtoHSV(float r, float g, float b, out float out_h, out float out_s, out float out_v)
		{
			fixed (float* out_h2 = &out_h)
			{
				fixed (float* out_s2 = &out_s)
				{
					fixed (float* out_v2 = &out_v)
					{
						ImGuiNative.igColorConvertRGBtoHSV(r, g, b, out_h2, out_s2, out_v2);
					}
				}
			}
		}

		public unsafe static Vector4 ColorConvertU32ToFloat4(uint @in)
		{
			Vector4 result = default(Vector4);
			ImGuiNative.igColorConvertU32ToFloat4(&result, @in);
			return result;
		}

		public unsafe static bool ColorEdit3(string label, ref Vector3 col)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiColorEditFlags flags = ImGuiColorEditFlags.None;
			fixed (Vector3* col2 = &col)
			{
				byte num2 = ImGuiNative.igColorEdit3(ptr, col2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public unsafe static bool ColorEdit3(string label, ref Vector3 col, ImGuiColorEditFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			fixed (Vector3* col2 = &col)
			{
				byte num2 = ImGuiNative.igColorEdit3(ptr, col2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public unsafe static bool ColorEdit4(string label, ref Vector4 col)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiColorEditFlags flags = ImGuiColorEditFlags.None;
			fixed (Vector4* col2 = &col)
			{
				byte num2 = ImGuiNative.igColorEdit4(ptr, col2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public unsafe static bool ColorEdit4(string label, ref Vector4 col, ImGuiColorEditFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			fixed (Vector4* col2 = &col)
			{
				byte num2 = ImGuiNative.igColorEdit4(ptr, col2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public unsafe static bool ColorPicker3(string label, ref Vector3 col)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiColorEditFlags flags = ImGuiColorEditFlags.None;
			fixed (Vector3* col2 = &col)
			{
				byte num2 = ImGuiNative.igColorPicker3(ptr, col2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public unsafe static bool ColorPicker3(string label, ref Vector3 col, ImGuiColorEditFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			fixed (Vector3* col2 = &col)
			{
				byte num2 = ImGuiNative.igColorPicker3(ptr, col2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public unsafe static bool ColorPicker4(string label, ref Vector4 col)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiColorEditFlags flags = ImGuiColorEditFlags.None;
			float* ref_col = null;
			fixed (Vector4* col2 = &col)
			{
				byte num2 = ImGuiNative.igColorPicker4(ptr, col2, flags, ref_col);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public unsafe static bool ColorPicker4(string label, ref Vector4 col, ImGuiColorEditFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float* ref_col = null;
			fixed (Vector4* col2 = &col)
			{
				byte num2 = ImGuiNative.igColorPicker4(ptr, col2, flags, ref_col);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public unsafe static bool ColorPicker4(string label, ref Vector4 col, ImGuiColorEditFlags flags, ref float ref_col)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			fixed (Vector4* col2 = &col)
			{
				fixed (float* ref_col2 = &ref_col)
				{
					byte num2 = ImGuiNative.igColorPicker4(ptr, col2, flags, ref_col2);
					if (num > 2048)
					{
						Util.Free(ptr);
					}
					return num2 != 0;
				}
			}
		}

		public unsafe static void Columns()
		{
			byte* id = null;
			byte border = 1;
			ImGuiNative.igColumns(1, id, border);
		}

		public unsafe static void Columns(int count)
		{
			byte* id = null;
			byte border = 1;
			ImGuiNative.igColumns(count, id, border);
		}

		public unsafe static void Columns(int count, string id)
		{
			int num = 0;
			byte* ptr;
			if (id != null)
			{
				num = Encoding.UTF8.GetByteCount(id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte border = 1;
			ImGuiNative.igColumns(count, ptr, border);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void Columns(int count, string id, bool border)
		{
			int num = 0;
			byte* ptr;
			if (id != null)
			{
				num = Encoding.UTF8.GetByteCount(id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte border2 = (byte)(border ? 1 : 0);
			ImGuiNative.igColumns(count, ptr, border2);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static bool Combo(string label, ref int current_item, string[] items, int items_count)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int* ptr2 = stackalloc int[items.Length];
			int num2 = 0;
			for (int i = 0; i < items.Length; i++)
			{
				string s = items[i];
				ptr2[i] = Encoding.UTF8.GetByteCount(s);
				num2 += ptr2[i] + 1;
			}
			byte* ptr3 = stackalloc byte[(int)(uint)num2];
			int num3 = 0;
			for (int j = 0; j < items.Length; j++)
			{
				string text = items[j];
				fixed (char* chars = text)
				{
					num3 += Encoding.UTF8.GetBytes(chars, text.Length, ptr3 + num3, ptr2[j]);
					ptr3[num3] = 0;
					num3++;
				}
			}
			byte** ptr4 = stackalloc byte*[items.Length];
			num3 = 0;
			for (int k = 0; k < items.Length; k++)
			{
				ptr4[k] = ptr3 + num3;
				num3 += ptr2[k] + 1;
			}
			int popup_max_height_in_items = -1;
			fixed (int* current_item2 = &current_item)
			{
				byte num4 = ImGuiNative.igCombo_Str_arr(ptr, current_item2, ptr4, items_count, popup_max_height_in_items);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num4 != 0;
			}
		}

		public unsafe static bool Combo(string label, ref int current_item, string[] items, int items_count, int popup_max_height_in_items)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int* ptr2 = stackalloc int[items.Length];
			int num2 = 0;
			for (int i = 0; i < items.Length; i++)
			{
				string s = items[i];
				ptr2[i] = Encoding.UTF8.GetByteCount(s);
				num2 += ptr2[i] + 1;
			}
			byte* ptr3 = stackalloc byte[(int)(uint)num2];
			int num3 = 0;
			for (int j = 0; j < items.Length; j++)
			{
				string text = items[j];
				fixed (char* chars = text)
				{
					num3 += Encoding.UTF8.GetBytes(chars, text.Length, ptr3 + num3, ptr2[j]);
					ptr3[num3] = 0;
					num3++;
				}
			}
			byte** ptr4 = stackalloc byte*[items.Length];
			num3 = 0;
			for (int k = 0; k < items.Length; k++)
			{
				ptr4[k] = ptr3 + num3;
				num3 += ptr2[k] + 1;
			}
			fixed (int* current_item2 = &current_item)
			{
				byte num4 = ImGuiNative.igCombo_Str_arr(ptr, current_item2, ptr4, items_count, popup_max_height_in_items);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num4 != 0;
			}
		}

		public unsafe static bool Combo(string label, ref int current_item, string items_separated_by_zeros)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (items_separated_by_zeros != null)
			{
				num2 = Encoding.UTF8.GetByteCount(items_separated_by_zeros);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(items_separated_by_zeros, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			int popup_max_height_in_items = -1;
			fixed (int* current_item2 = &current_item)
			{
				byte num3 = ImGuiNative.igCombo_Str(ptr, current_item2, ptr2, popup_max_height_in_items);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool Combo(string label, ref int current_item, string items_separated_by_zeros, int popup_max_height_in_items)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (items_separated_by_zeros != null)
			{
				num2 = Encoding.UTF8.GetByteCount(items_separated_by_zeros);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(items_separated_by_zeros, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (int* current_item2 = &current_item)
			{
				byte num3 = ImGuiNative.igCombo_Str(ptr, current_item2, ptr2, popup_max_height_in_items);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static IntPtr CreateContext()
		{
			ImFontAtlas* shared_font_atlas = null;
			return ImGuiNative.igCreateContext(shared_font_atlas);
		}

		public unsafe static IntPtr CreateContext(ImFontAtlasPtr shared_font_atlas)
		{
			return ImGuiNative.igCreateContext(shared_font_atlas.NativePtr);
		}

		public unsafe static bool DebugCheckVersionAndDataLayout(string version_str, uint sz_io, uint sz_style, uint sz_vec2, uint sz_vec4, uint sz_drawvert, uint sz_drawidx)
		{
			int num = 0;
			byte* ptr;
			if (version_str != null)
			{
				num = Encoding.UTF8.GetByteCount(version_str);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(version_str, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igDebugCheckVersionAndDataLayout(ptr, sz_io, sz_style, sz_vec2, sz_vec4, sz_drawvert, sz_drawidx);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static void DebugTextEncoding(string text)
		{
			int num = 0;
			byte* ptr;
			if (text != null)
			{
				num = Encoding.UTF8.GetByteCount(text);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(text, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igDebugTextEncoding(ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public static void DestroyContext()
		{
			ImGuiNative.igDestroyContext(IntPtr.Zero);
		}

		public static void DestroyContext(IntPtr ctx)
		{
			ImGuiNative.igDestroyContext(ctx);
		}

		public static void DestroyPlatformWindows()
		{
			ImGuiNative.igDestroyPlatformWindows();
		}

		public unsafe static uint DockSpace(uint id)
		{
			Vector2 size = default(Vector2);
			ImGuiDockNodeFlags flags = ImGuiDockNodeFlags.None;
			ImGuiWindowClass* window_class = null;
			return ImGuiNative.igDockSpace(id, size, flags, window_class);
		}

		public unsafe static uint DockSpace(uint id, Vector2 size)
		{
			ImGuiDockNodeFlags flags = ImGuiDockNodeFlags.None;
			ImGuiWindowClass* window_class = null;
			return ImGuiNative.igDockSpace(id, size, flags, window_class);
		}

		public unsafe static uint DockSpace(uint id, Vector2 size, ImGuiDockNodeFlags flags)
		{
			ImGuiWindowClass* window_class = null;
			return ImGuiNative.igDockSpace(id, size, flags, window_class);
		}

		public unsafe static uint DockSpace(uint id, Vector2 size, ImGuiDockNodeFlags flags, ImGuiWindowClassPtr window_class)
		{
			ImGuiWindowClass* nativePtr = window_class.NativePtr;
			return ImGuiNative.igDockSpace(id, size, flags, nativePtr);
		}

		public unsafe static uint DockSpaceOverViewport()
		{
			ImGuiViewport* viewport = null;
			ImGuiDockNodeFlags flags = ImGuiDockNodeFlags.None;
			ImGuiWindowClass* window_class = null;
			return ImGuiNative.igDockSpaceOverViewport(viewport, flags, window_class);
		}

		public unsafe static uint DockSpaceOverViewport(ImGuiViewportPtr viewport)
		{
			ImGuiViewport* nativePtr = viewport.NativePtr;
			ImGuiDockNodeFlags flags = ImGuiDockNodeFlags.None;
			ImGuiWindowClass* window_class = null;
			return ImGuiNative.igDockSpaceOverViewport(nativePtr, flags, window_class);
		}

		public unsafe static uint DockSpaceOverViewport(ImGuiViewportPtr viewport, ImGuiDockNodeFlags flags)
		{
			ImGuiViewport* nativePtr = viewport.NativePtr;
			ImGuiWindowClass* window_class = null;
			return ImGuiNative.igDockSpaceOverViewport(nativePtr, flags, window_class);
		}

		public unsafe static uint DockSpaceOverViewport(ImGuiViewportPtr viewport, ImGuiDockNodeFlags flags, ImGuiWindowClassPtr window_class)
		{
			ImGuiViewport* nativePtr = viewport.NativePtr;
			ImGuiWindowClass* nativePtr2 = window_class.NativePtr;
			return ImGuiNative.igDockSpaceOverViewport(nativePtr, flags, nativePtr2);
		}

		public unsafe static bool DragFloat(string label, ref float v)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_speed = 1f;
			float v_min = 0f;
			float v_max = 0f;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (float* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat(string label, ref float v, float v_speed)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_min = 0f;
			float v_max = 0f;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (float* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat(string label, ref float v, float v_speed, float v_min)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_max = 0f;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (float* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat(string label, ref float v, float v_speed, float v_min, float v_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (float* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat(string label, ref float v, float v_speed, float v_min, float v_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (float* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat(string label, ref float v, float v_speed, float v_min, float v_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (float* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat2(string label, ref Vector2 v)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_speed = 1f;
			float v_min = 0f;
			float v_max = 0f;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector2* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat2(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat2(string label, ref Vector2 v, float v_speed)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_min = 0f;
			float v_max = 0f;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector2* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat2(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat2(string label, ref Vector2 v, float v_speed, float v_min)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_max = 0f;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector2* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat2(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat2(string label, ref Vector2 v, float v_speed, float v_min, float v_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector2* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat2(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat2(string label, ref Vector2 v, float v_speed, float v_min, float v_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector2* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat2(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat2(string label, ref Vector2 v, float v_speed, float v_min, float v_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (Vector2* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat2(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat3(string label, ref Vector3 v)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_speed = 1f;
			float v_min = 0f;
			float v_max = 0f;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector3* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat3(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat3(string label, ref Vector3 v, float v_speed)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_min = 0f;
			float v_max = 0f;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector3* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat3(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat3(string label, ref Vector3 v, float v_speed, float v_min)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_max = 0f;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector3* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat3(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat3(string label, ref Vector3 v, float v_speed, float v_min, float v_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector3* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat3(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat3(string label, ref Vector3 v, float v_speed, float v_min, float v_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector3* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat3(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat3(string label, ref Vector3 v, float v_speed, float v_min, float v_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (Vector3* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat3(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat4(string label, ref Vector4 v)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_speed = 1f;
			float v_min = 0f;
			float v_max = 0f;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector4* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat4(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat4(string label, ref Vector4 v, float v_speed)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_min = 0f;
			float v_max = 0f;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector4* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat4(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat4(string label, ref Vector4 v, float v_speed, float v_min)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_max = 0f;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector4* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat4(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat4(string label, ref Vector4 v, float v_speed, float v_min, float v_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector4* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat4(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat4(string label, ref Vector4 v, float v_speed, float v_min, float v_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector4* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat4(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloat4(string label, ref Vector4 v, float v_speed, float v_min, float v_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (Vector4* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragFloat4(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragFloatRange2(string label, ref float v_current_min, ref float v_current_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_speed = 1f;
			float v_min = 0f;
			float v_max = 0f;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			byte* format_max = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (float* v_current_min2 = &v_current_min)
			{
				fixed (float* v_current_max2 = &v_current_max)
				{
					byte num3 = ImGuiNative.igDragFloatRange2(ptr, v_current_min2, v_current_max2, v_speed, v_min, v_max, ptr2, format_max, flags);
					if (num > 2048)
					{
						Util.Free(ptr);
					}
					if (num2 > 2048)
					{
						Util.Free(ptr2);
					}
					return num3 != 0;
				}
			}
		}

		public unsafe static bool DragFloatRange2(string label, ref float v_current_min, ref float v_current_max, float v_speed)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_min = 0f;
			float v_max = 0f;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			byte* format_max = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (float* v_current_min2 = &v_current_min)
			{
				fixed (float* v_current_max2 = &v_current_max)
				{
					byte num3 = ImGuiNative.igDragFloatRange2(ptr, v_current_min2, v_current_max2, v_speed, v_min, v_max, ptr2, format_max, flags);
					if (num > 2048)
					{
						Util.Free(ptr);
					}
					if (num2 > 2048)
					{
						Util.Free(ptr2);
					}
					return num3 != 0;
				}
			}
		}

		public unsafe static bool DragFloatRange2(string label, ref float v_current_min, ref float v_current_max, float v_speed, float v_min)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_max = 0f;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			byte* format_max = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (float* v_current_min2 = &v_current_min)
			{
				fixed (float* v_current_max2 = &v_current_max)
				{
					byte num3 = ImGuiNative.igDragFloatRange2(ptr, v_current_min2, v_current_max2, v_speed, v_min, v_max, ptr2, format_max, flags);
					if (num > 2048)
					{
						Util.Free(ptr);
					}
					if (num2 > 2048)
					{
						Util.Free(ptr2);
					}
					return num3 != 0;
				}
			}
		}

		public unsafe static bool DragFloatRange2(string label, ref float v_current_min, ref float v_current_max, float v_speed, float v_min, float v_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			byte* format_max = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (float* v_current_min2 = &v_current_min)
			{
				fixed (float* v_current_max2 = &v_current_max)
				{
					byte num3 = ImGuiNative.igDragFloatRange2(ptr, v_current_min2, v_current_max2, v_speed, v_min, v_max, ptr2, format_max, flags);
					if (num > 2048)
					{
						Util.Free(ptr);
					}
					if (num2 > 2048)
					{
						Util.Free(ptr2);
					}
					return num3 != 0;
				}
			}
		}

		public unsafe static bool DragFloatRange2(string label, ref float v_current_min, ref float v_current_max, float v_speed, float v_min, float v_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			byte* format_max = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (float* v_current_min2 = &v_current_min)
			{
				fixed (float* v_current_max2 = &v_current_max)
				{
					byte num3 = ImGuiNative.igDragFloatRange2(ptr, v_current_min2, v_current_max2, v_speed, v_min, v_max, ptr2, format_max, flags);
					if (num > 2048)
					{
						Util.Free(ptr);
					}
					if (num2 > 2048)
					{
						Util.Free(ptr2);
					}
					return num3 != 0;
				}
			}
		}

		public unsafe static bool DragFloatRange2(string label, ref float v_current_min, ref float v_current_max, float v_speed, float v_min, float v_max, string format, string format_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			int num3 = 0;
			byte* ptr3;
			if (format_max != null)
			{
				num3 = Encoding.UTF8.GetByteCount(format_max);
				ptr3 = ((num3 <= 2048) ? stackalloc byte[(int)(uint)(num3 + 1)] : Util.Allocate(num3 + 1));
				int utf3 = Util.GetUtf8(format_max, ptr3, num3);
				ptr3[utf3] = 0;
			}
			else
			{
				ptr3 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (float* v_current_min2 = &v_current_min)
			{
				fixed (float* v_current_max2 = &v_current_max)
				{
					byte num4 = ImGuiNative.igDragFloatRange2(ptr, v_current_min2, v_current_max2, v_speed, v_min, v_max, ptr2, ptr3, flags);
					if (num > 2048)
					{
						Util.Free(ptr);
					}
					if (num2 > 2048)
					{
						Util.Free(ptr2);
					}
					if (num3 > 2048)
					{
						Util.Free(ptr3);
					}
					return num4 != 0;
				}
			}
		}

		public unsafe static bool DragFloatRange2(string label, ref float v_current_min, ref float v_current_max, float v_speed, float v_min, float v_max, string format, string format_max, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			int num3 = 0;
			byte* ptr3;
			if (format_max != null)
			{
				num3 = Encoding.UTF8.GetByteCount(format_max);
				ptr3 = ((num3 <= 2048) ? stackalloc byte[(int)(uint)(num3 + 1)] : Util.Allocate(num3 + 1));
				int utf3 = Util.GetUtf8(format_max, ptr3, num3);
				ptr3[utf3] = 0;
			}
			else
			{
				ptr3 = null;
			}
			fixed (float* v_current_min2 = &v_current_min)
			{
				fixed (float* v_current_max2 = &v_current_max)
				{
					byte num4 = ImGuiNative.igDragFloatRange2(ptr, v_current_min2, v_current_max2, v_speed, v_min, v_max, ptr2, ptr3, flags);
					if (num > 2048)
					{
						Util.Free(ptr);
					}
					if (num2 > 2048)
					{
						Util.Free(ptr2);
					}
					if (num3 > 2048)
					{
						Util.Free(ptr3);
					}
					return num4 != 0;
				}
			}
		}

		public unsafe static bool DragInt(string label, ref int v)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_speed = 1f;
			int v_min = 0;
			int v_max = 0;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt(string label, ref int v, float v_speed)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int v_min = 0;
			int v_max = 0;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt(string label, ref int v, float v_speed, int v_min)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int v_max = 0;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt(string label, ref int v, float v_speed, int v_min, int v_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt(string label, ref int v, float v_speed, int v_min, int v_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt(string label, ref int v, float v_speed, int v_min, int v_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt2(string label, ref int v)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_speed = 1f;
			int v_min = 0;
			int v_max = 0;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt2(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt2(string label, ref int v, float v_speed)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int v_min = 0;
			int v_max = 0;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt2(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt2(string label, ref int v, float v_speed, int v_min)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int v_max = 0;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt2(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt2(string label, ref int v, float v_speed, int v_min, int v_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt2(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt2(string label, ref int v, float v_speed, int v_min, int v_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt2(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt2(string label, ref int v, float v_speed, int v_min, int v_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt2(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt3(string label, ref int v)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_speed = 1f;
			int v_min = 0;
			int v_max = 0;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt3(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt3(string label, ref int v, float v_speed)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int v_min = 0;
			int v_max = 0;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt3(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt3(string label, ref int v, float v_speed, int v_min)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int v_max = 0;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt3(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt3(string label, ref int v, float v_speed, int v_min, int v_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt3(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt3(string label, ref int v, float v_speed, int v_min, int v_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt3(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt3(string label, ref int v, float v_speed, int v_min, int v_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt3(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt4(string label, ref int v)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_speed = 1f;
			int v_min = 0;
			int v_max = 0;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt4(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt4(string label, ref int v, float v_speed)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int v_min = 0;
			int v_max = 0;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt4(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt4(string label, ref int v, float v_speed, int v_min)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int v_max = 0;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt4(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt4(string label, ref int v, float v_speed, int v_min, int v_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt4(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt4(string label, ref int v, float v_speed, int v_min, int v_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt4(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragInt4(string label, ref int v, float v_speed, int v_min, int v_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igDragInt4(ptr, v2, v_speed, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool DragIntRange2(string label, ref int v_current_min, ref int v_current_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_speed = 1f;
			int v_min = 0;
			int v_max = 0;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			byte* format_max = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v_current_min2 = &v_current_min)
			{
				fixed (int* v_current_max2 = &v_current_max)
				{
					byte num3 = ImGuiNative.igDragIntRange2(ptr, v_current_min2, v_current_max2, v_speed, v_min, v_max, ptr2, format_max, flags);
					if (num > 2048)
					{
						Util.Free(ptr);
					}
					if (num2 > 2048)
					{
						Util.Free(ptr2);
					}
					return num3 != 0;
				}
			}
		}

		public unsafe static bool DragIntRange2(string label, ref int v_current_min, ref int v_current_max, float v_speed)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int v_min = 0;
			int v_max = 0;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			byte* format_max = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v_current_min2 = &v_current_min)
			{
				fixed (int* v_current_max2 = &v_current_max)
				{
					byte num3 = ImGuiNative.igDragIntRange2(ptr, v_current_min2, v_current_max2, v_speed, v_min, v_max, ptr2, format_max, flags);
					if (num > 2048)
					{
						Util.Free(ptr);
					}
					if (num2 > 2048)
					{
						Util.Free(ptr2);
					}
					return num3 != 0;
				}
			}
		}

		public unsafe static bool DragIntRange2(string label, ref int v_current_min, ref int v_current_max, float v_speed, int v_min)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int v_max = 0;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			byte* format_max = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v_current_min2 = &v_current_min)
			{
				fixed (int* v_current_max2 = &v_current_max)
				{
					byte num3 = ImGuiNative.igDragIntRange2(ptr, v_current_min2, v_current_max2, v_speed, v_min, v_max, ptr2, format_max, flags);
					if (num > 2048)
					{
						Util.Free(ptr);
					}
					if (num2 > 2048)
					{
						Util.Free(ptr2);
					}
					return num3 != 0;
				}
			}
		}

		public unsafe static bool DragIntRange2(string label, ref int v_current_min, ref int v_current_max, float v_speed, int v_min, int v_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			byte* format_max = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v_current_min2 = &v_current_min)
			{
				fixed (int* v_current_max2 = &v_current_max)
				{
					byte num3 = ImGuiNative.igDragIntRange2(ptr, v_current_min2, v_current_max2, v_speed, v_min, v_max, ptr2, format_max, flags);
					if (num > 2048)
					{
						Util.Free(ptr);
					}
					if (num2 > 2048)
					{
						Util.Free(ptr2);
					}
					return num3 != 0;
				}
			}
		}

		public unsafe static bool DragIntRange2(string label, ref int v_current_min, ref int v_current_max, float v_speed, int v_min, int v_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			byte* format_max = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v_current_min2 = &v_current_min)
			{
				fixed (int* v_current_max2 = &v_current_max)
				{
					byte num3 = ImGuiNative.igDragIntRange2(ptr, v_current_min2, v_current_max2, v_speed, v_min, v_max, ptr2, format_max, flags);
					if (num > 2048)
					{
						Util.Free(ptr);
					}
					if (num2 > 2048)
					{
						Util.Free(ptr2);
					}
					return num3 != 0;
				}
			}
		}

		public unsafe static bool DragIntRange2(string label, ref int v_current_min, ref int v_current_max, float v_speed, int v_min, int v_max, string format, string format_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			int num3 = 0;
			byte* ptr3;
			if (format_max != null)
			{
				num3 = Encoding.UTF8.GetByteCount(format_max);
				ptr3 = ((num3 <= 2048) ? stackalloc byte[(int)(uint)(num3 + 1)] : Util.Allocate(num3 + 1));
				int utf3 = Util.GetUtf8(format_max, ptr3, num3);
				ptr3[utf3] = 0;
			}
			else
			{
				ptr3 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v_current_min2 = &v_current_min)
			{
				fixed (int* v_current_max2 = &v_current_max)
				{
					byte num4 = ImGuiNative.igDragIntRange2(ptr, v_current_min2, v_current_max2, v_speed, v_min, v_max, ptr2, ptr3, flags);
					if (num > 2048)
					{
						Util.Free(ptr);
					}
					if (num2 > 2048)
					{
						Util.Free(ptr2);
					}
					if (num3 > 2048)
					{
						Util.Free(ptr3);
					}
					return num4 != 0;
				}
			}
		}

		public unsafe static bool DragIntRange2(string label, ref int v_current_min, ref int v_current_max, float v_speed, int v_min, int v_max, string format, string format_max, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			int num3 = 0;
			byte* ptr3;
			if (format_max != null)
			{
				num3 = Encoding.UTF8.GetByteCount(format_max);
				ptr3 = ((num3 <= 2048) ? stackalloc byte[(int)(uint)(num3 + 1)] : Util.Allocate(num3 + 1));
				int utf3 = Util.GetUtf8(format_max, ptr3, num3);
				ptr3[utf3] = 0;
			}
			else
			{
				ptr3 = null;
			}
			fixed (int* v_current_min2 = &v_current_min)
			{
				fixed (int* v_current_max2 = &v_current_max)
				{
					byte num4 = ImGuiNative.igDragIntRange2(ptr, v_current_min2, v_current_max2, v_speed, v_min, v_max, ptr2, ptr3, flags);
					if (num > 2048)
					{
						Util.Free(ptr);
					}
					if (num2 > 2048)
					{
						Util.Free(ptr2);
					}
					if (num3 > 2048)
					{
						Util.Free(ptr3);
					}
					return num4 != 0;
				}
			}
		}

		public unsafe static bool DragScalar(string label, ImGuiDataType data_type, IntPtr p_data)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			float v_speed = 1f;
			void* p_min = null;
			void* p_max = null;
			byte* format = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			byte num2 = ImGuiNative.igDragScalar(ptr, data_type, p_data2, v_speed, p_min, p_max, format, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool DragScalar(string label, ImGuiDataType data_type, IntPtr p_data, float v_speed)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_min = null;
			void* p_max = null;
			byte* format = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			byte num2 = ImGuiNative.igDragScalar(ptr, data_type, p_data2, v_speed, p_min, p_max, format, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool DragScalar(string label, ImGuiDataType data_type, IntPtr p_data, float v_speed, IntPtr p_min)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_min2 = p_min.ToPointer();
			void* p_max = null;
			byte* format = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			byte num2 = ImGuiNative.igDragScalar(ptr, data_type, p_data2, v_speed, p_min2, p_max, format, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool DragScalar(string label, ImGuiDataType data_type, IntPtr p_data, float v_speed, IntPtr p_min, IntPtr p_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_min2 = p_min.ToPointer();
			void* p_max2 = p_max.ToPointer();
			byte* format = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			byte num2 = ImGuiNative.igDragScalar(ptr, data_type, p_data2, v_speed, p_min2, p_max2, format, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool DragScalar(string label, ImGuiDataType data_type, IntPtr p_data, float v_speed, IntPtr p_min, IntPtr p_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_min2 = p_min.ToPointer();
			void* p_max2 = p_max.ToPointer();
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			byte num3 = ImGuiNative.igDragScalar(ptr, data_type, p_data2, v_speed, p_min2, p_max2, ptr2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public unsafe static bool DragScalar(string label, ImGuiDataType data_type, IntPtr p_data, float v_speed, IntPtr p_min, IntPtr p_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_min2 = p_min.ToPointer();
			void* p_max2 = p_max.ToPointer();
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			byte num3 = ImGuiNative.igDragScalar(ptr, data_type, p_data2, v_speed, p_min2, p_max2, ptr2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public unsafe static bool DragScalarN(string label, ImGuiDataType data_type, IntPtr p_data, int components)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			float v_speed = 1f;
			void* p_min = null;
			void* p_max = null;
			byte* format = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			byte num2 = ImGuiNative.igDragScalarN(ptr, data_type, p_data2, components, v_speed, p_min, p_max, format, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool DragScalarN(string label, ImGuiDataType data_type, IntPtr p_data, int components, float v_speed)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_min = null;
			void* p_max = null;
			byte* format = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			byte num2 = ImGuiNative.igDragScalarN(ptr, data_type, p_data2, components, v_speed, p_min, p_max, format, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool DragScalarN(string label, ImGuiDataType data_type, IntPtr p_data, int components, float v_speed, IntPtr p_min)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_min2 = p_min.ToPointer();
			void* p_max = null;
			byte* format = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			byte num2 = ImGuiNative.igDragScalarN(ptr, data_type, p_data2, components, v_speed, p_min2, p_max, format, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool DragScalarN(string label, ImGuiDataType data_type, IntPtr p_data, int components, float v_speed, IntPtr p_min, IntPtr p_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_min2 = p_min.ToPointer();
			void* p_max2 = p_max.ToPointer();
			byte* format = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			byte num2 = ImGuiNative.igDragScalarN(ptr, data_type, p_data2, components, v_speed, p_min2, p_max2, format, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool DragScalarN(string label, ImGuiDataType data_type, IntPtr p_data, int components, float v_speed, IntPtr p_min, IntPtr p_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_min2 = p_min.ToPointer();
			void* p_max2 = p_max.ToPointer();
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			byte num3 = ImGuiNative.igDragScalarN(ptr, data_type, p_data2, components, v_speed, p_min2, p_max2, ptr2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public unsafe static bool DragScalarN(string label, ImGuiDataType data_type, IntPtr p_data, int components, float v_speed, IntPtr p_min, IntPtr p_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_min2 = p_min.ToPointer();
			void* p_max2 = p_max.ToPointer();
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			byte num3 = ImGuiNative.igDragScalarN(ptr, data_type, p_data2, components, v_speed, p_min2, p_max2, ptr2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public static void Dummy(Vector2 size)
		{
			ImGuiNative.igDummy(size);
		}

		public static void End()
		{
			ImGuiNative.igEnd();
		}

		public static void EndChild()
		{
			ImGuiNative.igEndChild();
		}

		public static void EndChildFrame()
		{
			ImGuiNative.igEndChildFrame();
		}

		public static void EndCombo()
		{
			ImGuiNative.igEndCombo();
		}

		public static void EndDisabled()
		{
			ImGuiNative.igEndDisabled();
		}

		public static void EndDragDropSource()
		{
			ImGuiNative.igEndDragDropSource();
		}

		public static void EndDragDropTarget()
		{
			ImGuiNative.igEndDragDropTarget();
		}

		public static void EndFrame()
		{
			ImGuiNative.igEndFrame();
		}

		public static void EndGroup()
		{
			ImGuiNative.igEndGroup();
		}

		public static void EndListBox()
		{
			ImGuiNative.igEndListBox();
		}

		public static void EndMainMenuBar()
		{
			ImGuiNative.igEndMainMenuBar();
		}

		public static void EndMenu()
		{
			ImGuiNative.igEndMenu();
		}

		public static void EndMenuBar()
		{
			ImGuiNative.igEndMenuBar();
		}

		public static void EndPopup()
		{
			ImGuiNative.igEndPopup();
		}

		public static void EndTabBar()
		{
			ImGuiNative.igEndTabBar();
		}

		public static void EndTabItem()
		{
			ImGuiNative.igEndTabItem();
		}

		public static void EndTable()
		{
			ImGuiNative.igEndTable();
		}

		public static void EndTooltip()
		{
			ImGuiNative.igEndTooltip();
		}

		public unsafe static ImGuiViewportPtr FindViewportByID(uint id)
		{
			return new ImGuiViewportPtr(ImGuiNative.igFindViewportByID(id));
		}

		public unsafe static ImGuiViewportPtr FindViewportByPlatformHandle(IntPtr platform_handle)
		{
			return new ImGuiViewportPtr(ImGuiNative.igFindViewportByPlatformHandle(platform_handle.ToPointer()));
		}

		public unsafe static void GetAllocatorFunctions(ref IntPtr p_alloc_func, ref IntPtr p_free_func, ref void* p_user_data)
		{
			fixed (IntPtr* p_alloc_func2 = &p_alloc_func)
			{
				fixed (IntPtr* p_free_func2 = &p_free_func)
				{
					fixed (void** p_user_data2 = &p_user_data)
					{
						ImGuiNative.igGetAllocatorFunctions(p_alloc_func2, p_free_func2, p_user_data2);
					}
				}
			}
		}

		public unsafe static ImDrawListPtr GetBackgroundDrawList()
		{
			return new ImDrawListPtr(ImGuiNative.igGetBackgroundDrawList_Nil());
		}

		public unsafe static ImDrawListPtr GetBackgroundDrawList(ImGuiViewportPtr viewport)
		{
			return new ImDrawListPtr(ImGuiNative.igGetBackgroundDrawList_ViewportPtr(viewport.NativePtr));
		}

		public unsafe static string GetClipboardText()
		{
			return Util.StringFromPtr(ImGuiNative.igGetClipboardText());
		}

		public static uint GetColorU32(ImGuiCol idx)
		{
			float alpha_mul = 1f;
			return ImGuiNative.igGetColorU32_Col(idx, alpha_mul);
		}

		public static uint GetColorU32(ImGuiCol idx, float alpha_mul)
		{
			return ImGuiNative.igGetColorU32_Col(idx, alpha_mul);
		}

		public static uint GetColorU32(Vector4 col)
		{
			return ImGuiNative.igGetColorU32_Vec4(col);
		}

		public static uint GetColorU32(uint col)
		{
			return ImGuiNative.igGetColorU32_U32(col);
		}

		public static int GetColumnIndex()
		{
			return ImGuiNative.igGetColumnIndex();
		}

		public static float GetColumnOffset()
		{
			return ImGuiNative.igGetColumnOffset(-1);
		}

		public static float GetColumnOffset(int column_index)
		{
			return ImGuiNative.igGetColumnOffset(column_index);
		}

		public static int GetColumnsCount()
		{
			return ImGuiNative.igGetColumnsCount();
		}

		public static float GetColumnWidth()
		{
			return ImGuiNative.igGetColumnWidth(-1);
		}

		public static float GetColumnWidth(int column_index)
		{
			return ImGuiNative.igGetColumnWidth(column_index);
		}

		public unsafe static Vector2 GetContentRegionAvail()
		{
			Vector2 result = default(Vector2);
			ImGuiNative.igGetContentRegionAvail(&result);
			return result;
		}

		public unsafe static Vector2 GetContentRegionMax()
		{
			Vector2 result = default(Vector2);
			ImGuiNative.igGetContentRegionMax(&result);
			return result;
		}

		public static IntPtr GetCurrentContext()
		{
			return ImGuiNative.igGetCurrentContext();
		}

		public unsafe static Vector2 GetCursorPos()
		{
			Vector2 result = default(Vector2);
			ImGuiNative.igGetCursorPos(&result);
			return result;
		}

		public static float GetCursorPosX()
		{
			return ImGuiNative.igGetCursorPosX();
		}

		public static float GetCursorPosY()
		{
			return ImGuiNative.igGetCursorPosY();
		}

		public unsafe static Vector2 GetCursorScreenPos()
		{
			Vector2 result = default(Vector2);
			ImGuiNative.igGetCursorScreenPos(&result);
			return result;
		}

		public unsafe static Vector2 GetCursorStartPos()
		{
			Vector2 result = default(Vector2);
			ImGuiNative.igGetCursorStartPos(&result);
			return result;
		}

		public unsafe static ImGuiPayloadPtr GetDragDropPayload()
		{
			return new ImGuiPayloadPtr(ImGuiNative.igGetDragDropPayload());
		}

		public unsafe static ImDrawDataPtr GetDrawData()
		{
			return new ImDrawDataPtr(ImGuiNative.igGetDrawData());
		}

		public static IntPtr GetDrawListSharedData()
		{
			return ImGuiNative.igGetDrawListSharedData();
		}

		public unsafe static ImFontPtr GetFont()
		{
			return new ImFontPtr(ImGuiNative.igGetFont());
		}

		public static float GetFontSize()
		{
			return ImGuiNative.igGetFontSize();
		}

		public unsafe static Vector2 GetFontTexUvWhitePixel()
		{
			Vector2 result = default(Vector2);
			ImGuiNative.igGetFontTexUvWhitePixel(&result);
			return result;
		}

		public unsafe static ImDrawListPtr GetForegroundDrawList()
		{
			return new ImDrawListPtr(ImGuiNative.igGetForegroundDrawList_Nil());
		}

		public unsafe static ImDrawListPtr GetForegroundDrawList(ImGuiViewportPtr viewport)
		{
			return new ImDrawListPtr(ImGuiNative.igGetForegroundDrawList_ViewportPtr(viewport.NativePtr));
		}

		public static int GetFrameCount()
		{
			return ImGuiNative.igGetFrameCount();
		}

		public static float GetFrameHeight()
		{
			return ImGuiNative.igGetFrameHeight();
		}

		public static float GetFrameHeightWithSpacing()
		{
			return ImGuiNative.igGetFrameHeightWithSpacing();
		}

		public unsafe static uint GetID(string str_id)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			uint result = ImGuiNative.igGetID_Str(ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return result;
		}

		public unsafe static uint GetID(IntPtr ptr_id)
		{
			return ImGuiNative.igGetID_Ptr(ptr_id.ToPointer());
		}

		public unsafe static ImGuiIOPtr GetIO()
		{
			return new ImGuiIOPtr(ImGuiNative.igGetIO());
		}

		public static uint GetItemID()
		{
			return ImGuiNative.igGetItemID();
		}

		public unsafe static Vector2 GetItemRectMax()
		{
			Vector2 result = default(Vector2);
			ImGuiNative.igGetItemRectMax(&result);
			return result;
		}

		public unsafe static Vector2 GetItemRectMin()
		{
			Vector2 result = default(Vector2);
			ImGuiNative.igGetItemRectMin(&result);
			return result;
		}

		public unsafe static Vector2 GetItemRectSize()
		{
			Vector2 result = default(Vector2);
			ImGuiNative.igGetItemRectSize(&result);
			return result;
		}

		public static ImGuiKey GetKeyIndex(ImGuiKey key)
		{
			return ImGuiNative.igGetKeyIndex(key);
		}

		public unsafe static string GetKeyName(ImGuiKey key)
		{
			return Util.StringFromPtr(ImGuiNative.igGetKeyName(key));
		}

		public static int GetKeyPressedAmount(ImGuiKey key, float repeat_delay, float rate)
		{
			return ImGuiNative.igGetKeyPressedAmount(key, repeat_delay, rate);
		}

		public unsafe static ImGuiViewportPtr GetMainViewport()
		{
			return new ImGuiViewportPtr(ImGuiNative.igGetMainViewport());
		}

		public static int GetMouseClickedCount(ImGuiMouseButton button)
		{
			return ImGuiNative.igGetMouseClickedCount(button);
		}

		public static ImGuiMouseCursor GetMouseCursor()
		{
			return ImGuiNative.igGetMouseCursor();
		}

		public unsafe static Vector2 GetMouseDragDelta()
		{
			ImGuiMouseButton button = ImGuiMouseButton.Left;
			float lock_threshold = -1f;
			Vector2 result = default(Vector2);
			ImGuiNative.igGetMouseDragDelta(&result, button, lock_threshold);
			return result;
		}

		public unsafe static Vector2 GetMouseDragDelta(ImGuiMouseButton button)
		{
			float lock_threshold = -1f;
			Vector2 result = default(Vector2);
			ImGuiNative.igGetMouseDragDelta(&result, button, lock_threshold);
			return result;
		}

		public unsafe static Vector2 GetMouseDragDelta(ImGuiMouseButton button, float lock_threshold)
		{
			Vector2 result = default(Vector2);
			ImGuiNative.igGetMouseDragDelta(&result, button, lock_threshold);
			return result;
		}

		public unsafe static Vector2 GetMousePos()
		{
			Vector2 result = default(Vector2);
			ImGuiNative.igGetMousePos(&result);
			return result;
		}

		public unsafe static Vector2 GetMousePosOnOpeningCurrentPopup()
		{
			Vector2 result = default(Vector2);
			ImGuiNative.igGetMousePosOnOpeningCurrentPopup(&result);
			return result;
		}

		public unsafe static ImGuiPlatformIOPtr GetPlatformIO()
		{
			return new ImGuiPlatformIOPtr(ImGuiNative.igGetPlatformIO());
		}

		public static float GetScrollMaxX()
		{
			return ImGuiNative.igGetScrollMaxX();
		}

		public static float GetScrollMaxY()
		{
			return ImGuiNative.igGetScrollMaxY();
		}

		public static float GetScrollX()
		{
			return ImGuiNative.igGetScrollX();
		}

		public static float GetScrollY()
		{
			return ImGuiNative.igGetScrollY();
		}

		public unsafe static ImGuiStoragePtr GetStateStorage()
		{
			return new ImGuiStoragePtr(ImGuiNative.igGetStateStorage());
		}

		public unsafe static ImGuiStylePtr GetStyle()
		{
			return new ImGuiStylePtr(ImGuiNative.igGetStyle());
		}

		public unsafe static string GetStyleColorName(ImGuiCol idx)
		{
			return Util.StringFromPtr(ImGuiNative.igGetStyleColorName(idx));
		}

		public unsafe static Vector4* GetStyleColorVec4(ImGuiCol idx)
		{
			return ImGuiNative.igGetStyleColorVec4(idx);
		}

		public static float GetTextLineHeight()
		{
			return ImGuiNative.igGetTextLineHeight();
		}

		public static float GetTextLineHeightWithSpacing()
		{
			return ImGuiNative.igGetTextLineHeightWithSpacing();
		}

		public static double GetTime()
		{
			return ImGuiNative.igGetTime();
		}

		public static float GetTreeNodeToLabelSpacing()
		{
			return ImGuiNative.igGetTreeNodeToLabelSpacing();
		}

		public unsafe static string GetVersion()
		{
			return Util.StringFromPtr(ImGuiNative.igGetVersion());
		}

		public unsafe static Vector2 GetWindowContentRegionMax()
		{
			Vector2 result = default(Vector2);
			ImGuiNative.igGetWindowContentRegionMax(&result);
			return result;
		}

		public unsafe static Vector2 GetWindowContentRegionMin()
		{
			Vector2 result = default(Vector2);
			ImGuiNative.igGetWindowContentRegionMin(&result);
			return result;
		}

		public static uint GetWindowDockID()
		{
			return ImGuiNative.igGetWindowDockID();
		}

		public static float GetWindowDpiScale()
		{
			return ImGuiNative.igGetWindowDpiScale();
		}

		public unsafe static ImDrawListPtr GetWindowDrawList()
		{
			return new ImDrawListPtr(ImGuiNative.igGetWindowDrawList());
		}

		public static float GetWindowHeight()
		{
			return ImGuiNative.igGetWindowHeight();
		}

		public unsafe static Vector2 GetWindowPos()
		{
			Vector2 result = default(Vector2);
			ImGuiNative.igGetWindowPos(&result);
			return result;
		}

		public unsafe static Vector2 GetWindowSize()
		{
			Vector2 result = default(Vector2);
			ImGuiNative.igGetWindowSize(&result);
			return result;
		}

		public unsafe static ImGuiViewportPtr GetWindowViewport()
		{
			return new ImGuiViewportPtr(ImGuiNative.igGetWindowViewport());
		}

		public static float GetWindowWidth()
		{
			return ImGuiNative.igGetWindowWidth();
		}

		public static void Image(IntPtr user_texture_id, Vector2 size)
		{
			Vector2 uv = default(Vector2);
			Vector2 uv2 = new Vector2(1f, 1f);
			Vector4 tint_col = new Vector4(1f, 1f, 1f, 1f);
			ImGuiNative.igImage(user_texture_id, size, uv, uv2, tint_col, default(Vector4));
		}

		public static void Image(IntPtr user_texture_id, Vector2 size, Vector2 uv0)
		{
			Vector2 uv1 = new Vector2(1f, 1f);
			Vector4 tint_col = new Vector4(1f, 1f, 1f, 1f);
			ImGuiNative.igImage(user_texture_id, size, uv0, uv1, tint_col, default(Vector4));
		}

		public static void Image(IntPtr user_texture_id, Vector2 size, Vector2 uv0, Vector2 uv1)
		{
			Vector4 tint_col = new Vector4(1f, 1f, 1f, 1f);
			ImGuiNative.igImage(user_texture_id, size, uv0, uv1, tint_col, default(Vector4));
		}

		public static void Image(IntPtr user_texture_id, Vector2 size, Vector2 uv0, Vector2 uv1, Vector4 tint_col)
		{
			ImGuiNative.igImage(user_texture_id, size, uv0, uv1, tint_col, default(Vector4));
		}

		public static void Image(IntPtr user_texture_id, Vector2 size, Vector2 uv0, Vector2 uv1, Vector4 tint_col, Vector4 border_col)
		{
			ImGuiNative.igImage(user_texture_id, size, uv0, uv1, tint_col, border_col);
		}

		public unsafe static bool ImageButton(string str_id, IntPtr user_texture_id, Vector2 size)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			Vector2 uv = default(Vector2);
			Vector2 uv2 = new Vector2(1f, 1f);
			Vector4 bg_col = default(Vector4);
			Vector4 tint_col = new Vector4(1f, 1f, 1f, 1f);
			byte num2 = ImGuiNative.igImageButton(ptr, user_texture_id, size, uv, uv2, bg_col, tint_col);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool ImageButton(string str_id, IntPtr user_texture_id, Vector2 size, Vector2 uv0)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			Vector2 uv1 = new Vector2(1f, 1f);
			Vector4 bg_col = default(Vector4);
			Vector4 tint_col = new Vector4(1f, 1f, 1f, 1f);
			byte num2 = ImGuiNative.igImageButton(ptr, user_texture_id, size, uv0, uv1, bg_col, tint_col);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool ImageButton(string str_id, IntPtr user_texture_id, Vector2 size, Vector2 uv0, Vector2 uv1)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			Vector4 bg_col = default(Vector4);
			Vector4 tint_col = new Vector4(1f, 1f, 1f, 1f);
			byte num2 = ImGuiNative.igImageButton(ptr, user_texture_id, size, uv0, uv1, bg_col, tint_col);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool ImageButton(string str_id, IntPtr user_texture_id, Vector2 size, Vector2 uv0, Vector2 uv1, Vector4 bg_col)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			Vector4 tint_col = new Vector4(1f, 1f, 1f, 1f);
			byte num2 = ImGuiNative.igImageButton(ptr, user_texture_id, size, uv0, uv1, bg_col, tint_col);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool ImageButton(string str_id, IntPtr user_texture_id, Vector2 size, Vector2 uv0, Vector2 uv1, Vector4 bg_col, Vector4 tint_col)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igImageButton(ptr, user_texture_id, size, uv0, uv1, bg_col, tint_col);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public static void Indent()
		{
			ImGuiNative.igIndent(0f);
		}

		public static void Indent(float indent_w)
		{
			ImGuiNative.igIndent(indent_w);
		}

		public unsafe static bool InputDouble(string label, ref double v)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			double step = 0.0;
			double step_fast = 0.0;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.6f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.6f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			fixed (double* v2 = &v)
			{
				byte num3 = ImGuiNative.igInputDouble(ptr, v2, step, step_fast, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool InputDouble(string label, ref double v, double step)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			double step_fast = 0.0;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.6f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.6f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			fixed (double* v2 = &v)
			{
				byte num3 = ImGuiNative.igInputDouble(ptr, v2, step, step_fast, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool InputDouble(string label, ref double v, double step, double step_fast)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.6f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.6f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			fixed (double* v2 = &v)
			{
				byte num3 = ImGuiNative.igInputDouble(ptr, v2, step, step_fast, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool InputDouble(string label, ref double v, double step, double step_fast, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			fixed (double* v2 = &v)
			{
				byte num3 = ImGuiNative.igInputDouble(ptr, v2, step, step_fast, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool InputDouble(string label, ref double v, double step, double step_fast, string format, ImGuiInputTextFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (double* v2 = &v)
			{
				byte num3 = ImGuiNative.igInputDouble(ptr, v2, step, step_fast, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool InputFloat(string label, ref float v)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float step = 0f;
			float step_fast = 0f;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			fixed (float* v2 = &v)
			{
				byte num3 = ImGuiNative.igInputFloat(ptr, v2, step, step_fast, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool InputFloat(string label, ref float v, float step)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float step_fast = 0f;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			fixed (float* v2 = &v)
			{
				byte num3 = ImGuiNative.igInputFloat(ptr, v2, step, step_fast, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool InputFloat(string label, ref float v, float step, float step_fast)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			fixed (float* v2 = &v)
			{
				byte num3 = ImGuiNative.igInputFloat(ptr, v2, step, step_fast, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool InputFloat(string label, ref float v, float step, float step_fast, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			fixed (float* v2 = &v)
			{
				byte num3 = ImGuiNative.igInputFloat(ptr, v2, step, step_fast, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool InputFloat(string label, ref float v, float step, float step_fast, string format, ImGuiInputTextFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (float* v2 = &v)
			{
				byte num3 = ImGuiNative.igInputFloat(ptr, v2, step, step_fast, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool InputFloat2(string label, ref Vector2 v)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			fixed (Vector2* v2 = &v)
			{
				byte num3 = ImGuiNative.igInputFloat2(ptr, v2, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool InputFloat2(string label, ref Vector2 v, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			fixed (Vector2* v2 = &v)
			{
				byte num3 = ImGuiNative.igInputFloat2(ptr, v2, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool InputFloat2(string label, ref Vector2 v, string format, ImGuiInputTextFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (Vector2* v2 = &v)
			{
				byte num3 = ImGuiNative.igInputFloat2(ptr, v2, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool InputFloat3(string label, ref Vector3 v)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			fixed (Vector3* v2 = &v)
			{
				byte num3 = ImGuiNative.igInputFloat3(ptr, v2, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool InputFloat3(string label, ref Vector3 v, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			fixed (Vector3* v2 = &v)
			{
				byte num3 = ImGuiNative.igInputFloat3(ptr, v2, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool InputFloat3(string label, ref Vector3 v, string format, ImGuiInputTextFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (Vector3* v2 = &v)
			{
				byte num3 = ImGuiNative.igInputFloat3(ptr, v2, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool InputFloat4(string label, ref Vector4 v)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			fixed (Vector4* v2 = &v)
			{
				byte num3 = ImGuiNative.igInputFloat4(ptr, v2, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool InputFloat4(string label, ref Vector4 v, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			fixed (Vector4* v2 = &v)
			{
				byte num3 = ImGuiNative.igInputFloat4(ptr, v2, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool InputFloat4(string label, ref Vector4 v, string format, ImGuiInputTextFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (Vector4* v2 = &v)
			{
				byte num3 = ImGuiNative.igInputFloat4(ptr, v2, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool InputInt(string label, ref int v)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int step = 1;
			int step_fast = 100;
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			fixed (int* v2 = &v)
			{
				byte num2 = ImGuiNative.igInputInt(ptr, v2, step, step_fast, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public unsafe static bool InputInt(string label, ref int v, int step)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int step_fast = 100;
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			fixed (int* v2 = &v)
			{
				byte num2 = ImGuiNative.igInputInt(ptr, v2, step, step_fast, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public unsafe static bool InputInt(string label, ref int v, int step, int step_fast)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			fixed (int* v2 = &v)
			{
				byte num2 = ImGuiNative.igInputInt(ptr, v2, step, step_fast, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public unsafe static bool InputInt(string label, ref int v, int step, int step_fast, ImGuiInputTextFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			fixed (int* v2 = &v)
			{
				byte num2 = ImGuiNative.igInputInt(ptr, v2, step, step_fast, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public unsafe static bool InputInt2(string label, ref int v)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			fixed (int* v2 = &v)
			{
				byte num2 = ImGuiNative.igInputInt2(ptr, v2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public unsafe static bool InputInt2(string label, ref int v, ImGuiInputTextFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			fixed (int* v2 = &v)
			{
				byte num2 = ImGuiNative.igInputInt2(ptr, v2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public unsafe static bool InputInt3(string label, ref int v)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			fixed (int* v2 = &v)
			{
				byte num2 = ImGuiNative.igInputInt3(ptr, v2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public unsafe static bool InputInt3(string label, ref int v, ImGuiInputTextFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			fixed (int* v2 = &v)
			{
				byte num2 = ImGuiNative.igInputInt3(ptr, v2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public unsafe static bool InputInt4(string label, ref int v)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			fixed (int* v2 = &v)
			{
				byte num2 = ImGuiNative.igInputInt4(ptr, v2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public unsafe static bool InputInt4(string label, ref int v, ImGuiInputTextFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			fixed (int* v2 = &v)
			{
				byte num2 = ImGuiNative.igInputInt4(ptr, v2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public unsafe static bool InputScalar(string label, ImGuiDataType data_type, IntPtr p_data)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_step = null;
			void* p_step_fast = null;
			byte* format = null;
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			byte num2 = ImGuiNative.igInputScalar(ptr, data_type, p_data2, p_step, p_step_fast, format, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool InputScalar(string label, ImGuiDataType data_type, IntPtr p_data, IntPtr p_step)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_step2 = p_step.ToPointer();
			void* p_step_fast = null;
			byte* format = null;
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			byte num2 = ImGuiNative.igInputScalar(ptr, data_type, p_data2, p_step2, p_step_fast, format, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool InputScalar(string label, ImGuiDataType data_type, IntPtr p_data, IntPtr p_step, IntPtr p_step_fast)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_step2 = p_step.ToPointer();
			void* p_step_fast2 = p_step_fast.ToPointer();
			byte* format = null;
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			byte num2 = ImGuiNative.igInputScalar(ptr, data_type, p_data2, p_step2, p_step_fast2, format, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool InputScalar(string label, ImGuiDataType data_type, IntPtr p_data, IntPtr p_step, IntPtr p_step_fast, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_step2 = p_step.ToPointer();
			void* p_step_fast2 = p_step_fast.ToPointer();
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			byte num3 = ImGuiNative.igInputScalar(ptr, data_type, p_data2, p_step2, p_step_fast2, ptr2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public unsafe static bool InputScalar(string label, ImGuiDataType data_type, IntPtr p_data, IntPtr p_step, IntPtr p_step_fast, string format, ImGuiInputTextFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_step2 = p_step.ToPointer();
			void* p_step_fast2 = p_step_fast.ToPointer();
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			byte num3 = ImGuiNative.igInputScalar(ptr, data_type, p_data2, p_step2, p_step_fast2, ptr2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public unsafe static bool InputScalarN(string label, ImGuiDataType data_type, IntPtr p_data, int components)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_step = null;
			void* p_step_fast = null;
			byte* format = null;
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			byte num2 = ImGuiNative.igInputScalarN(ptr, data_type, p_data2, components, p_step, p_step_fast, format, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool InputScalarN(string label, ImGuiDataType data_type, IntPtr p_data, int components, IntPtr p_step)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_step2 = p_step.ToPointer();
			void* p_step_fast = null;
			byte* format = null;
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			byte num2 = ImGuiNative.igInputScalarN(ptr, data_type, p_data2, components, p_step2, p_step_fast, format, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool InputScalarN(string label, ImGuiDataType data_type, IntPtr p_data, int components, IntPtr p_step, IntPtr p_step_fast)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_step2 = p_step.ToPointer();
			void* p_step_fast2 = p_step_fast.ToPointer();
			byte* format = null;
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			byte num2 = ImGuiNative.igInputScalarN(ptr, data_type, p_data2, components, p_step2, p_step_fast2, format, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool InputScalarN(string label, ImGuiDataType data_type, IntPtr p_data, int components, IntPtr p_step, IntPtr p_step_fast, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_step2 = p_step.ToPointer();
			void* p_step_fast2 = p_step_fast.ToPointer();
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiInputTextFlags flags = ImGuiInputTextFlags.None;
			byte num3 = ImGuiNative.igInputScalarN(ptr, data_type, p_data2, components, p_step2, p_step_fast2, ptr2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public unsafe static bool InputScalarN(string label, ImGuiDataType data_type, IntPtr p_data, int components, IntPtr p_step, IntPtr p_step_fast, string format, ImGuiInputTextFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_step2 = p_step.ToPointer();
			void* p_step_fast2 = p_step_fast.ToPointer();
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			byte num3 = ImGuiNative.igInputScalarN(ptr, data_type, p_data2, components, p_step2, p_step_fast2, ptr2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public unsafe static bool InvisibleButton(string str_id, Vector2 size)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiButtonFlags flags = ImGuiButtonFlags.None;
			byte num2 = ImGuiNative.igInvisibleButton(ptr, size, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool InvisibleButton(string str_id, Vector2 size, ImGuiButtonFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igInvisibleButton(ptr, size, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public static bool IsAnyItemActive()
		{
			return ImGuiNative.igIsAnyItemActive() != 0;
		}

		public static bool IsAnyItemFocused()
		{
			return ImGuiNative.igIsAnyItemFocused() != 0;
		}

		public static bool IsAnyItemHovered()
		{
			return ImGuiNative.igIsAnyItemHovered() != 0;
		}

		public static bool IsAnyMouseDown()
		{
			return ImGuiNative.igIsAnyMouseDown() != 0;
		}

		public static bool IsItemActivated()
		{
			return ImGuiNative.igIsItemActivated() != 0;
		}

		public static bool IsItemActive()
		{
			return ImGuiNative.igIsItemActive() != 0;
		}

		public static bool IsItemClicked()
		{
			return ImGuiNative.igIsItemClicked(ImGuiMouseButton.Left) != 0;
		}

		public static bool IsItemClicked(ImGuiMouseButton mouse_button)
		{
			return ImGuiNative.igIsItemClicked(mouse_button) != 0;
		}

		public static bool IsItemDeactivated()
		{
			return ImGuiNative.igIsItemDeactivated() != 0;
		}

		public static bool IsItemDeactivatedAfterEdit()
		{
			return ImGuiNative.igIsItemDeactivatedAfterEdit() != 0;
		}

		public static bool IsItemEdited()
		{
			return ImGuiNative.igIsItemEdited() != 0;
		}

		public static bool IsItemFocused()
		{
			return ImGuiNative.igIsItemFocused() != 0;
		}

		public static bool IsItemHovered()
		{
			return ImGuiNative.igIsItemHovered(ImGuiHoveredFlags.None) != 0;
		}

		public static bool IsItemHovered(ImGuiHoveredFlags flags)
		{
			return ImGuiNative.igIsItemHovered(flags) != 0;
		}

		public static bool IsItemToggledOpen()
		{
			return ImGuiNative.igIsItemToggledOpen() != 0;
		}

		public static bool IsItemVisible()
		{
			return ImGuiNative.igIsItemVisible() != 0;
		}

		public static bool IsKeyDown(ImGuiKey key)
		{
			return ImGuiNative.igIsKeyDown_Nil(key) != 0;
		}

		public static bool IsKeyPressed(ImGuiKey key)
		{
			byte repeat = 1;
			return ImGuiNative.igIsKeyPressed_Bool(key, repeat) != 0;
		}

		public static bool IsKeyPressed(ImGuiKey key, bool repeat)
		{
			byte repeat2 = (byte)(repeat ? 1 : 0);
			return ImGuiNative.igIsKeyPressed_Bool(key, repeat2) != 0;
		}

		public static bool IsKeyReleased(ImGuiKey key)
		{
			return ImGuiNative.igIsKeyReleased_Nil(key) != 0;
		}

		public static bool IsMouseClicked(ImGuiMouseButton button)
		{
			byte repeat = 0;
			return ImGuiNative.igIsMouseClicked_Bool(button, repeat) != 0;
		}

		public static bool IsMouseClicked(ImGuiMouseButton button, bool repeat)
		{
			byte repeat2 = (byte)(repeat ? 1 : 0);
			return ImGuiNative.igIsMouseClicked_Bool(button, repeat2) != 0;
		}

		public static bool IsMouseDoubleClicked(ImGuiMouseButton button)
		{
			return ImGuiNative.igIsMouseDoubleClicked(button) != 0;
		}

		public static bool IsMouseDown(ImGuiMouseButton button)
		{
			return ImGuiNative.igIsMouseDown_Nil(button) != 0;
		}

		public static bool IsMouseDragging(ImGuiMouseButton button)
		{
			float lock_threshold = -1f;
			return ImGuiNative.igIsMouseDragging(button, lock_threshold) != 0;
		}

		public static bool IsMouseDragging(ImGuiMouseButton button, float lock_threshold)
		{
			return ImGuiNative.igIsMouseDragging(button, lock_threshold) != 0;
		}

		public static bool IsMouseHoveringRect(Vector2 r_min, Vector2 r_max)
		{
			byte clip = 1;
			return ImGuiNative.igIsMouseHoveringRect(r_min, r_max, clip) != 0;
		}

		public static bool IsMouseHoveringRect(Vector2 r_min, Vector2 r_max, bool clip)
		{
			byte clip2 = (byte)(clip ? 1 : 0);
			return ImGuiNative.igIsMouseHoveringRect(r_min, r_max, clip2) != 0;
		}

		public unsafe static bool IsMousePosValid()
		{
			Vector2* mouse_pos = null;
			return ImGuiNative.igIsMousePosValid(mouse_pos) != 0;
		}

		public unsafe static bool IsMousePosValid(ref Vector2 mouse_pos)
		{
			fixed (Vector2* mouse_pos2 = &mouse_pos)
			{
				return ImGuiNative.igIsMousePosValid(mouse_pos2) != 0;
			}
		}

		public static bool IsMouseReleased(ImGuiMouseButton button)
		{
			return ImGuiNative.igIsMouseReleased_Nil(button) != 0;
		}

		public unsafe static bool IsPopupOpen(string str_id)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiPopupFlags flags = ImGuiPopupFlags.None;
			byte num2 = ImGuiNative.igIsPopupOpen_Str(ptr, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool IsPopupOpen(string str_id, ImGuiPopupFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igIsPopupOpen_Str(ptr, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public static bool IsRectVisible(Vector2 size)
		{
			return ImGuiNative.igIsRectVisible_Nil(size) != 0;
		}

		public static bool IsRectVisible(Vector2 rect_min, Vector2 rect_max)
		{
			return ImGuiNative.igIsRectVisible_Vec2(rect_min, rect_max) != 0;
		}

		public static bool IsWindowAppearing()
		{
			return ImGuiNative.igIsWindowAppearing() != 0;
		}

		public static bool IsWindowCollapsed()
		{
			return ImGuiNative.igIsWindowCollapsed() != 0;
		}

		public static bool IsWindowDocked()
		{
			return ImGuiNative.igIsWindowDocked() != 0;
		}

		public static bool IsWindowFocused()
		{
			return ImGuiNative.igIsWindowFocused(ImGuiFocusedFlags.None) != 0;
		}

		public static bool IsWindowFocused(ImGuiFocusedFlags flags)
		{
			return ImGuiNative.igIsWindowFocused(flags) != 0;
		}

		public static bool IsWindowHovered()
		{
			return ImGuiNative.igIsWindowHovered(ImGuiHoveredFlags.None) != 0;
		}

		public static bool IsWindowHovered(ImGuiHoveredFlags flags)
		{
			return ImGuiNative.igIsWindowHovered(flags) != 0;
		}

		public unsafe static void LabelText(string label, string fmt)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (fmt != null)
			{
				num2 = Encoding.UTF8.GetByteCount(fmt);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(fmt, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiNative.igLabelText(ptr, ptr2);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
		}

		public unsafe static bool ListBox(string label, ref int current_item, string[] items, int items_count)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int* ptr2 = stackalloc int[items.Length];
			int num2 = 0;
			for (int i = 0; i < items.Length; i++)
			{
				string s = items[i];
				ptr2[i] = Encoding.UTF8.GetByteCount(s);
				num2 += ptr2[i] + 1;
			}
			byte* ptr3 = stackalloc byte[(int)(uint)num2];
			int num3 = 0;
			for (int j = 0; j < items.Length; j++)
			{
				string text = items[j];
				fixed (char* chars = text)
				{
					num3 += Encoding.UTF8.GetBytes(chars, text.Length, ptr3 + num3, ptr2[j]);
					ptr3[num3] = 0;
					num3++;
				}
			}
			byte** ptr4 = stackalloc byte*[items.Length];
			num3 = 0;
			for (int k = 0; k < items.Length; k++)
			{
				ptr4[k] = ptr3 + num3;
				num3 += ptr2[k] + 1;
			}
			int height_in_items = -1;
			fixed (int* current_item2 = &current_item)
			{
				byte num4 = ImGuiNative.igListBox_Str_arr(ptr, current_item2, ptr4, items_count, height_in_items);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num4 != 0;
			}
		}

		public unsafe static bool ListBox(string label, ref int current_item, string[] items, int items_count, int height_in_items)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int* ptr2 = stackalloc int[items.Length];
			int num2 = 0;
			for (int i = 0; i < items.Length; i++)
			{
				string s = items[i];
				ptr2[i] = Encoding.UTF8.GetByteCount(s);
				num2 += ptr2[i] + 1;
			}
			byte* ptr3 = stackalloc byte[(int)(uint)num2];
			int num3 = 0;
			for (int j = 0; j < items.Length; j++)
			{
				string text = items[j];
				fixed (char* chars = text)
				{
					num3 += Encoding.UTF8.GetBytes(chars, text.Length, ptr3 + num3, ptr2[j]);
					ptr3[num3] = 0;
					num3++;
				}
			}
			byte** ptr4 = stackalloc byte*[items.Length];
			num3 = 0;
			for (int k = 0; k < items.Length; k++)
			{
				ptr4[k] = ptr3 + num3;
				num3 += ptr2[k] + 1;
			}
			fixed (int* current_item2 = &current_item)
			{
				byte num4 = ImGuiNative.igListBox_Str_arr(ptr, current_item2, ptr4, items_count, height_in_items);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num4 != 0;
			}
		}

		public unsafe static void LoadIniSettingsFromDisk(string ini_filename)
		{
			int num = 0;
			byte* ptr;
			if (ini_filename != null)
			{
				num = Encoding.UTF8.GetByteCount(ini_filename);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(ini_filename, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igLoadIniSettingsFromDisk(ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void LoadIniSettingsFromMemory(string ini_data)
		{
			int num = 0;
			byte* ptr;
			if (ini_data != null)
			{
				num = Encoding.UTF8.GetByteCount(ini_data);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(ini_data, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			uint ini_size = 0u;
			ImGuiNative.igLoadIniSettingsFromMemory(ptr, ini_size);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void LoadIniSettingsFromMemory(string ini_data, uint ini_size)
		{
			int num = 0;
			byte* ptr;
			if (ini_data != null)
			{
				num = Encoding.UTF8.GetByteCount(ini_data);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(ini_data, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igLoadIniSettingsFromMemory(ptr, ini_size);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public static void LogButtons()
		{
			ImGuiNative.igLogButtons();
		}

		public static void LogFinish()
		{
			ImGuiNative.igLogFinish();
		}

		public unsafe static void LogText(string fmt)
		{
			int num = 0;
			byte* ptr;
			if (fmt != null)
			{
				num = Encoding.UTF8.GetByteCount(fmt);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(fmt, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igLogText(ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public static void LogToClipboard()
		{
			ImGuiNative.igLogToClipboard(-1);
		}

		public static void LogToClipboard(int auto_open_depth)
		{
			ImGuiNative.igLogToClipboard(auto_open_depth);
		}

		public unsafe static void LogToFile()
		{
			byte* filename = null;
			ImGuiNative.igLogToFile(-1, filename);
		}

		public unsafe static void LogToFile(int auto_open_depth)
		{
			byte* filename = null;
			ImGuiNative.igLogToFile(auto_open_depth, filename);
		}

		public unsafe static void LogToFile(int auto_open_depth, string filename)
		{
			int num = 0;
			byte* ptr;
			if (filename != null)
			{
				num = Encoding.UTF8.GetByteCount(filename);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(filename, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igLogToFile(auto_open_depth, ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public static void LogToTTY()
		{
			ImGuiNative.igLogToTTY(-1);
		}

		public static void LogToTTY(int auto_open_depth)
		{
			ImGuiNative.igLogToTTY(auto_open_depth);
		}

		public unsafe static IntPtr MemAlloc(uint size)
		{
			return (IntPtr)ImGuiNative.igMemAlloc(size);
		}

		public unsafe static void MemFree(IntPtr ptr)
		{
			ImGuiNative.igMemFree(ptr.ToPointer());
		}

		public unsafe static bool MenuItem(string label)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte* shortcut = null;
			byte selected = 0;
			byte enabled = 1;
			byte num2 = ImGuiNative.igMenuItem_Bool(ptr, shortcut, selected, enabled);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool MenuItem(string label, string shortcut)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (shortcut != null)
			{
				num2 = Encoding.UTF8.GetByteCount(shortcut);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(shortcut, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			byte selected = 0;
			byte enabled = 1;
			byte num3 = ImGuiNative.igMenuItem_Bool(ptr, ptr2, selected, enabled);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public unsafe static bool MenuItem(string label, string shortcut, bool selected)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (shortcut != null)
			{
				num2 = Encoding.UTF8.GetByteCount(shortcut);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(shortcut, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			byte selected2 = (byte)(selected ? 1 : 0);
			byte enabled = 1;
			byte num3 = ImGuiNative.igMenuItem_Bool(ptr, ptr2, selected2, enabled);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public unsafe static bool MenuItem(string label, string shortcut, bool selected, bool enabled)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (shortcut != null)
			{
				num2 = Encoding.UTF8.GetByteCount(shortcut);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(shortcut, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			byte selected2 = (byte)(selected ? 1 : 0);
			byte enabled2 = (byte)(enabled ? 1 : 0);
			byte num3 = ImGuiNative.igMenuItem_Bool(ptr, ptr2, selected2, enabled2);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public unsafe static bool MenuItem(string label, string shortcut, ref bool p_selected)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (shortcut != null)
			{
				num2 = Encoding.UTF8.GetByteCount(shortcut);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(shortcut, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			byte b = (byte)(p_selected ? 1 : 0);
			byte* p_selected2 = &b;
			byte enabled = 1;
			byte num3 = ImGuiNative.igMenuItem_BoolPtr(ptr, ptr2, p_selected2, enabled);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			p_selected = b != 0;
			return num3 != 0;
		}

		public unsafe static bool MenuItem(string label, string shortcut, ref bool p_selected, bool enabled)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (shortcut != null)
			{
				num2 = Encoding.UTF8.GetByteCount(shortcut);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(shortcut, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			byte b = (byte)(p_selected ? 1 : 0);
			byte* p_selected2 = &b;
			byte enabled2 = (byte)(enabled ? 1 : 0);
			byte num3 = ImGuiNative.igMenuItem_BoolPtr(ptr, ptr2, p_selected2, enabled2);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			p_selected = b != 0;
			return num3 != 0;
		}

		public static void NewFrame()
		{
			ImGuiNative.igNewFrame();
		}

		public static void NewLine()
		{
			ImGuiNative.igNewLine();
		}

		public static void NextColumn()
		{
			ImGuiNative.igNextColumn();
		}

		public unsafe static void OpenPopup(string str_id)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiPopupFlags popup_flags = ImGuiPopupFlags.None;
			ImGuiNative.igOpenPopup_Str(ptr, popup_flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void OpenPopup(string str_id, ImGuiPopupFlags popup_flags)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igOpenPopup_Str(ptr, popup_flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public static void OpenPopup(uint id)
		{
			ImGuiPopupFlags popup_flags = ImGuiPopupFlags.None;
			ImGuiNative.igOpenPopup_ID(id, popup_flags);
		}

		public static void OpenPopup(uint id, ImGuiPopupFlags popup_flags)
		{
			ImGuiNative.igOpenPopup_ID(id, popup_flags);
		}

		public unsafe static void OpenPopupOnItemClick()
		{
			byte* str_id = null;
			ImGuiPopupFlags popup_flags = ImGuiPopupFlags.MouseButtonRight;
			ImGuiNative.igOpenPopupOnItemClick(str_id, popup_flags);
		}

		public unsafe static void OpenPopupOnItemClick(string str_id)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiPopupFlags popup_flags = ImGuiPopupFlags.MouseButtonRight;
			ImGuiNative.igOpenPopupOnItemClick(ptr, popup_flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void OpenPopupOnItemClick(string str_id, ImGuiPopupFlags popup_flags)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igOpenPopupOnItemClick(ptr, popup_flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void PlotHistogram(string label, ref float values, int values_count)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int values_offset = 0;
			byte* overlay_text = null;
			float scale_min = float.MaxValue;
			float scale_max = float.MaxValue;
			Vector2 graph_size = default(Vector2);
			int stride = 4;
			fixed (float* values2 = &values)
			{
				ImGuiNative.igPlotHistogram_FloatPtr(ptr, values2, values_count, values_offset, overlay_text, scale_min, scale_max, graph_size, stride);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
			}
		}

		public unsafe static void PlotHistogram(string label, ref float values, int values_count, int values_offset)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte* overlay_text = null;
			float scale_min = float.MaxValue;
			float scale_max = float.MaxValue;
			Vector2 graph_size = default(Vector2);
			int stride = 4;
			fixed (float* values2 = &values)
			{
				ImGuiNative.igPlotHistogram_FloatPtr(ptr, values2, values_count, values_offset, overlay_text, scale_min, scale_max, graph_size, stride);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
			}
		}

		public unsafe static void PlotHistogram(string label, ref float values, int values_count, int values_offset, string overlay_text)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (overlay_text != null)
			{
				num2 = Encoding.UTF8.GetByteCount(overlay_text);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(overlay_text, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			float scale_min = float.MaxValue;
			float scale_max = float.MaxValue;
			Vector2 graph_size = default(Vector2);
			int stride = 4;
			fixed (float* values2 = &values)
			{
				ImGuiNative.igPlotHistogram_FloatPtr(ptr, values2, values_count, values_offset, ptr2, scale_min, scale_max, graph_size, stride);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
			}
		}

		public unsafe static void PlotHistogram(string label, ref float values, int values_count, int values_offset, string overlay_text, float scale_min)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (overlay_text != null)
			{
				num2 = Encoding.UTF8.GetByteCount(overlay_text);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(overlay_text, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			float scale_max = float.MaxValue;
			Vector2 graph_size = default(Vector2);
			int stride = 4;
			fixed (float* values2 = &values)
			{
				ImGuiNative.igPlotHistogram_FloatPtr(ptr, values2, values_count, values_offset, ptr2, scale_min, scale_max, graph_size, stride);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
			}
		}

		public unsafe static void PlotHistogram(string label, ref float values, int values_count, int values_offset, string overlay_text, float scale_min, float scale_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (overlay_text != null)
			{
				num2 = Encoding.UTF8.GetByteCount(overlay_text);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(overlay_text, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			Vector2 graph_size = default(Vector2);
			int stride = 4;
			fixed (float* values2 = &values)
			{
				ImGuiNative.igPlotHistogram_FloatPtr(ptr, values2, values_count, values_offset, ptr2, scale_min, scale_max, graph_size, stride);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
			}
		}

		public unsafe static void PlotHistogram(string label, ref float values, int values_count, int values_offset, string overlay_text, float scale_min, float scale_max, Vector2 graph_size)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (overlay_text != null)
			{
				num2 = Encoding.UTF8.GetByteCount(overlay_text);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(overlay_text, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			int stride = 4;
			fixed (float* values2 = &values)
			{
				ImGuiNative.igPlotHistogram_FloatPtr(ptr, values2, values_count, values_offset, ptr2, scale_min, scale_max, graph_size, stride);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
			}
		}

		public unsafe static void PlotHistogram(string label, ref float values, int values_count, int values_offset, string overlay_text, float scale_min, float scale_max, Vector2 graph_size, int stride)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (overlay_text != null)
			{
				num2 = Encoding.UTF8.GetByteCount(overlay_text);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(overlay_text, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (float* values2 = &values)
			{
				ImGuiNative.igPlotHistogram_FloatPtr(ptr, values2, values_count, values_offset, ptr2, scale_min, scale_max, graph_size, stride);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
			}
		}

		public unsafe static void PlotLines(string label, ref float values, int values_count)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int values_offset = 0;
			byte* overlay_text = null;
			float scale_min = float.MaxValue;
			float scale_max = float.MaxValue;
			Vector2 graph_size = default(Vector2);
			int stride = 4;
			fixed (float* values2 = &values)
			{
				ImGuiNative.igPlotLines_FloatPtr(ptr, values2, values_count, values_offset, overlay_text, scale_min, scale_max, graph_size, stride);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
			}
		}

		public unsafe static void PlotLines(string label, ref float values, int values_count, int values_offset)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte* overlay_text = null;
			float scale_min = float.MaxValue;
			float scale_max = float.MaxValue;
			Vector2 graph_size = default(Vector2);
			int stride = 4;
			fixed (float* values2 = &values)
			{
				ImGuiNative.igPlotLines_FloatPtr(ptr, values2, values_count, values_offset, overlay_text, scale_min, scale_max, graph_size, stride);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
			}
		}

		public unsafe static void PlotLines(string label, ref float values, int values_count, int values_offset, string overlay_text)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (overlay_text != null)
			{
				num2 = Encoding.UTF8.GetByteCount(overlay_text);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(overlay_text, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			float scale_min = float.MaxValue;
			float scale_max = float.MaxValue;
			Vector2 graph_size = default(Vector2);
			int stride = 4;
			fixed (float* values2 = &values)
			{
				ImGuiNative.igPlotLines_FloatPtr(ptr, values2, values_count, values_offset, ptr2, scale_min, scale_max, graph_size, stride);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
			}
		}

		public unsafe static void PlotLines(string label, ref float values, int values_count, int values_offset, string overlay_text, float scale_min)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (overlay_text != null)
			{
				num2 = Encoding.UTF8.GetByteCount(overlay_text);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(overlay_text, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			float scale_max = float.MaxValue;
			Vector2 graph_size = default(Vector2);
			int stride = 4;
			fixed (float* values2 = &values)
			{
				ImGuiNative.igPlotLines_FloatPtr(ptr, values2, values_count, values_offset, ptr2, scale_min, scale_max, graph_size, stride);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
			}
		}

		public unsafe static void PlotLines(string label, ref float values, int values_count, int values_offset, string overlay_text, float scale_min, float scale_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (overlay_text != null)
			{
				num2 = Encoding.UTF8.GetByteCount(overlay_text);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(overlay_text, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			Vector2 graph_size = default(Vector2);
			int stride = 4;
			fixed (float* values2 = &values)
			{
				ImGuiNative.igPlotLines_FloatPtr(ptr, values2, values_count, values_offset, ptr2, scale_min, scale_max, graph_size, stride);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
			}
		}

		public unsafe static void PlotLines(string label, ref float values, int values_count, int values_offset, string overlay_text, float scale_min, float scale_max, Vector2 graph_size)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (overlay_text != null)
			{
				num2 = Encoding.UTF8.GetByteCount(overlay_text);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(overlay_text, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			int stride = 4;
			fixed (float* values2 = &values)
			{
				ImGuiNative.igPlotLines_FloatPtr(ptr, values2, values_count, values_offset, ptr2, scale_min, scale_max, graph_size, stride);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
			}
		}

		public unsafe static void PlotLines(string label, ref float values, int values_count, int values_offset, string overlay_text, float scale_min, float scale_max, Vector2 graph_size, int stride)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (overlay_text != null)
			{
				num2 = Encoding.UTF8.GetByteCount(overlay_text);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(overlay_text, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (float* values2 = &values)
			{
				ImGuiNative.igPlotLines_FloatPtr(ptr, values2, values_count, values_offset, ptr2, scale_min, scale_max, graph_size, stride);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
			}
		}

		public static void PopAllowKeyboardFocus()
		{
			ImGuiNative.igPopAllowKeyboardFocus();
		}

		public static void PopButtonRepeat()
		{
			ImGuiNative.igPopButtonRepeat();
		}

		public static void PopClipRect()
		{
			ImGuiNative.igPopClipRect();
		}

		public static void PopFont()
		{
			ImGuiNative.igPopFont();
		}

		public static void PopID()
		{
			ImGuiNative.igPopID();
		}

		public static void PopItemWidth()
		{
			ImGuiNative.igPopItemWidth();
		}

		public static void PopStyleColor()
		{
			ImGuiNative.igPopStyleColor(1);
		}

		public static void PopStyleColor(int count)
		{
			ImGuiNative.igPopStyleColor(count);
		}

		public static void PopStyleVar()
		{
			ImGuiNative.igPopStyleVar(1);
		}

		public static void PopStyleVar(int count)
		{
			ImGuiNative.igPopStyleVar(count);
		}

		public static void PopTextWrapPos()
		{
			ImGuiNative.igPopTextWrapPos();
		}

		public unsafe static void ProgressBar(float fraction)
		{
			Vector2 size_arg = new Vector2(float.MaxValue, 0f);
			byte* overlay = null;
			ImGuiNative.igProgressBar(fraction, size_arg, overlay);
		}

		public unsafe static void ProgressBar(float fraction, Vector2 size_arg)
		{
			byte* overlay = null;
			ImGuiNative.igProgressBar(fraction, size_arg, overlay);
		}

		public unsafe static void ProgressBar(float fraction, Vector2 size_arg, string overlay)
		{
			int num = 0;
			byte* ptr;
			if (overlay != null)
			{
				num = Encoding.UTF8.GetByteCount(overlay);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(overlay, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igProgressBar(fraction, size_arg, ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public static void PushAllowKeyboardFocus(bool allow_keyboard_focus)
		{
			ImGuiNative.igPushAllowKeyboardFocus((byte)(allow_keyboard_focus ? 1 : 0));
		}

		public static void PushButtonRepeat(bool repeat)
		{
			ImGuiNative.igPushButtonRepeat((byte)(repeat ? 1 : 0));
		}

		public static void PushClipRect(Vector2 clip_rect_min, Vector2 clip_rect_max, bool intersect_with_current_clip_rect)
		{
			byte intersect_with_current_clip_rect2 = (byte)(intersect_with_current_clip_rect ? 1 : 0);
			ImGuiNative.igPushClipRect(clip_rect_min, clip_rect_max, intersect_with_current_clip_rect2);
		}

		public unsafe static void PushFont(ImFontPtr font)
		{
			ImGuiNative.igPushFont(font.NativePtr);
		}

		public unsafe static void PushID(string str_id)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igPushID_Str(ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void PushID(IntPtr ptr_id)
		{
			ImGuiNative.igPushID_Ptr(ptr_id.ToPointer());
		}

		public static void PushID(int int_id)
		{
			ImGuiNative.igPushID_Int(int_id);
		}

		public static void PushItemWidth(float item_width)
		{
			ImGuiNative.igPushItemWidth(item_width);
		}

		public static void PushStyleColor(ImGuiCol idx, uint col)
		{
			ImGuiNative.igPushStyleColor_U32(idx, col);
		}

		public static void PushStyleColor(ImGuiCol idx, Vector4 col)
		{
			ImGuiNative.igPushStyleColor_Vec4(idx, col);
		}

		public static void PushStyleVar(ImGuiStyleVar idx, float val)
		{
			ImGuiNative.igPushStyleVar_Float(idx, val);
		}

		public static void PushStyleVar(ImGuiStyleVar idx, Vector2 val)
		{
			ImGuiNative.igPushStyleVar_Vec2(idx, val);
		}

		public static void PushTextWrapPos()
		{
			ImGuiNative.igPushTextWrapPos(0f);
		}

		public static void PushTextWrapPos(float wrap_local_pos_x)
		{
			ImGuiNative.igPushTextWrapPos(wrap_local_pos_x);
		}

		public unsafe static bool RadioButton(string label, bool active)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte active2 = (byte)(active ? 1 : 0);
			byte num2 = ImGuiNative.igRadioButton_Bool(ptr, active2);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool RadioButton(string label, ref int v, int v_button)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			fixed (int* v2 = &v)
			{
				byte num2 = ImGuiNative.igRadioButton_IntPtr(ptr, v2, v_button);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				return num2 != 0;
			}
		}

		public static void Render()
		{
			ImGuiNative.igRender();
		}

		public unsafe static void RenderPlatformWindowsDefault()
		{
			void* platform_render_arg = null;
			void* renderer_render_arg = null;
			ImGuiNative.igRenderPlatformWindowsDefault(platform_render_arg, renderer_render_arg);
		}

		public unsafe static void RenderPlatformWindowsDefault(IntPtr platform_render_arg)
		{
			void* platform_render_arg2 = platform_render_arg.ToPointer();
			void* renderer_render_arg = null;
			ImGuiNative.igRenderPlatformWindowsDefault(platform_render_arg2, renderer_render_arg);
		}

		public unsafe static void RenderPlatformWindowsDefault(IntPtr platform_render_arg, IntPtr renderer_render_arg)
		{
			void* platform_render_arg2 = platform_render_arg.ToPointer();
			void* renderer_render_arg2 = renderer_render_arg.ToPointer();
			ImGuiNative.igRenderPlatformWindowsDefault(platform_render_arg2, renderer_render_arg2);
		}

		public static void ResetMouseDragDelta()
		{
			ImGuiNative.igResetMouseDragDelta(ImGuiMouseButton.Left);
		}

		public static void ResetMouseDragDelta(ImGuiMouseButton button)
		{
			ImGuiNative.igResetMouseDragDelta(button);
		}

		public static void SameLine()
		{
			float spacing = -1f;
			ImGuiNative.igSameLine(0f, spacing);
		}

		public static void SameLine(float offset_from_start_x)
		{
			float spacing = -1f;
			ImGuiNative.igSameLine(offset_from_start_x, spacing);
		}

		public static void SameLine(float offset_from_start_x, float spacing)
		{
			ImGuiNative.igSameLine(offset_from_start_x, spacing);
		}

		public unsafe static void SaveIniSettingsToDisk(string ini_filename)
		{
			int num = 0;
			byte* ptr;
			if (ini_filename != null)
			{
				num = Encoding.UTF8.GetByteCount(ini_filename);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(ini_filename, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igSaveIniSettingsToDisk(ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static string SaveIniSettingsToMemory()
		{
			uint* out_ini_size = null;
			return Util.StringFromPtr(ImGuiNative.igSaveIniSettingsToMemory(out_ini_size));
		}

		public unsafe static string SaveIniSettingsToMemory(out uint out_ini_size)
		{
			fixed (uint* out_ini_size2 = &out_ini_size)
			{
				return Util.StringFromPtr(ImGuiNative.igSaveIniSettingsToMemory(out_ini_size2));
			}
		}

		public unsafe static bool Selectable(string label)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte selected = 0;
			ImGuiSelectableFlags flags = ImGuiSelectableFlags.None;
			byte num2 = ImGuiNative.igSelectable_Bool(ptr, selected, flags, default(Vector2));
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool Selectable(string label, bool selected)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte selected2 = (byte)(selected ? 1 : 0);
			ImGuiSelectableFlags flags = ImGuiSelectableFlags.None;
			byte num2 = ImGuiNative.igSelectable_Bool(ptr, selected2, flags, default(Vector2));
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool Selectable(string label, bool selected, ImGuiSelectableFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte selected2 = (byte)(selected ? 1 : 0);
			byte num2 = ImGuiNative.igSelectable_Bool(ptr, selected2, flags, default(Vector2));
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool Selectable(string label, bool selected, ImGuiSelectableFlags flags, Vector2 size)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte selected2 = (byte)(selected ? 1 : 0);
			byte num2 = ImGuiNative.igSelectable_Bool(ptr, selected2, flags, size);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool Selectable(string label, ref bool p_selected)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte b = (byte)(p_selected ? 1 : 0);
			byte* p_selected2 = &b;
			ImGuiSelectableFlags flags = ImGuiSelectableFlags.None;
			byte num2 = ImGuiNative.igSelectable_BoolPtr(ptr, p_selected2, flags, default(Vector2));
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			p_selected = b != 0;
			return num2 != 0;
		}

		public unsafe static bool Selectable(string label, ref bool p_selected, ImGuiSelectableFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte b = (byte)(p_selected ? 1 : 0);
			byte* p_selected2 = &b;
			byte num2 = ImGuiNative.igSelectable_BoolPtr(ptr, p_selected2, flags, default(Vector2));
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			p_selected = b != 0;
			return num2 != 0;
		}

		public unsafe static bool Selectable(string label, ref bool p_selected, ImGuiSelectableFlags flags, Vector2 size)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte b = (byte)(p_selected ? 1 : 0);
			byte* p_selected2 = &b;
			byte num2 = ImGuiNative.igSelectable_BoolPtr(ptr, p_selected2, flags, size);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			p_selected = b != 0;
			return num2 != 0;
		}

		public static void Separator()
		{
			ImGuiNative.igSeparator();
		}

		public unsafe static void SetAllocatorFunctions(IntPtr alloc_func, IntPtr free_func)
		{
			void* user_data = null;
			ImGuiNative.igSetAllocatorFunctions(alloc_func, free_func, user_data);
		}

		public unsafe static void SetAllocatorFunctions(IntPtr alloc_func, IntPtr free_func, IntPtr user_data)
		{
			void* user_data2 = user_data.ToPointer();
			ImGuiNative.igSetAllocatorFunctions(alloc_func, free_func, user_data2);
		}

		public unsafe static void SetClipboardText(string text)
		{
			int num = 0;
			byte* ptr;
			if (text != null)
			{
				num = Encoding.UTF8.GetByteCount(text);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(text, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igSetClipboardText(ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public static void SetColorEditOptions(ImGuiColorEditFlags flags)
		{
			ImGuiNative.igSetColorEditOptions(flags);
		}

		public static void SetColumnOffset(int column_index, float offset_x)
		{
			ImGuiNative.igSetColumnOffset(column_index, offset_x);
		}

		public static void SetColumnWidth(int column_index, float width)
		{
			ImGuiNative.igSetColumnWidth(column_index, width);
		}

		public static void SetCurrentContext(IntPtr ctx)
		{
			ImGuiNative.igSetCurrentContext(ctx);
		}

		public static void SetCursorPos(Vector2 local_pos)
		{
			ImGuiNative.igSetCursorPos(local_pos);
		}

		public static void SetCursorPosX(float local_x)
		{
			ImGuiNative.igSetCursorPosX(local_x);
		}

		public static void SetCursorPosY(float local_y)
		{
			ImGuiNative.igSetCursorPosY(local_y);
		}

		public static void SetCursorScreenPos(Vector2 pos)
		{
			ImGuiNative.igSetCursorScreenPos(pos);
		}

		public unsafe static bool SetDragDropPayload(string type, IntPtr data, uint sz)
		{
			int num = 0;
			byte* ptr;
			if (type != null)
			{
				num = Encoding.UTF8.GetByteCount(type);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(type, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* data2 = data.ToPointer();
			ImGuiCond cond = ImGuiCond.None;
			byte num2 = ImGuiNative.igSetDragDropPayload(ptr, data2, sz, cond);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool SetDragDropPayload(string type, IntPtr data, uint sz, ImGuiCond cond)
		{
			int num = 0;
			byte* ptr;
			if (type != null)
			{
				num = Encoding.UTF8.GetByteCount(type);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(type, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* data2 = data.ToPointer();
			byte num2 = ImGuiNative.igSetDragDropPayload(ptr, data2, sz, cond);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public static void SetItemAllowOverlap()
		{
			ImGuiNative.igSetItemAllowOverlap();
		}

		public static void SetItemDefaultFocus()
		{
			ImGuiNative.igSetItemDefaultFocus();
		}

		public static void SetKeyboardFocusHere()
		{
			ImGuiNative.igSetKeyboardFocusHere(0);
		}

		public static void SetKeyboardFocusHere(int offset)
		{
			ImGuiNative.igSetKeyboardFocusHere(offset);
		}

		public static void SetMouseCursor(ImGuiMouseCursor cursor_type)
		{
			ImGuiNative.igSetMouseCursor(cursor_type);
		}

		public static void SetNextFrameWantCaptureKeyboard(bool want_capture_keyboard)
		{
			ImGuiNative.igSetNextFrameWantCaptureKeyboard((byte)(want_capture_keyboard ? 1 : 0));
		}

		public static void SetNextFrameWantCaptureMouse(bool want_capture_mouse)
		{
			ImGuiNative.igSetNextFrameWantCaptureMouse((byte)(want_capture_mouse ? 1 : 0));
		}

		public static void SetNextItemOpen(bool is_open)
		{
			int is_open2 = (is_open ? 1 : 0);
			ImGuiCond cond = ImGuiCond.None;
			ImGuiNative.igSetNextItemOpen((byte)is_open2, cond);
		}

		public static void SetNextItemOpen(bool is_open, ImGuiCond cond)
		{
			ImGuiNative.igSetNextItemOpen((byte)(is_open ? 1 : 0), cond);
		}

		public static void SetNextItemWidth(float item_width)
		{
			ImGuiNative.igSetNextItemWidth(item_width);
		}

		public static void SetNextWindowBgAlpha(float alpha)
		{
			ImGuiNative.igSetNextWindowBgAlpha(alpha);
		}

		public unsafe static void SetNextWindowClass(ImGuiWindowClassPtr window_class)
		{
			ImGuiNative.igSetNextWindowClass(window_class.NativePtr);
		}

		public static void SetNextWindowCollapsed(bool collapsed)
		{
			int collapsed2 = (collapsed ? 1 : 0);
			ImGuiCond cond = ImGuiCond.None;
			ImGuiNative.igSetNextWindowCollapsed((byte)collapsed2, cond);
		}

		public static void SetNextWindowCollapsed(bool collapsed, ImGuiCond cond)
		{
			ImGuiNative.igSetNextWindowCollapsed((byte)(collapsed ? 1 : 0), cond);
		}

		public static void SetNextWindowContentSize(Vector2 size)
		{
			ImGuiNative.igSetNextWindowContentSize(size);
		}

		public static void SetNextWindowDockID(uint dock_id)
		{
			ImGuiCond cond = ImGuiCond.None;
			ImGuiNative.igSetNextWindowDockID(dock_id, cond);
		}

		public static void SetNextWindowDockID(uint dock_id, ImGuiCond cond)
		{
			ImGuiNative.igSetNextWindowDockID(dock_id, cond);
		}

		public static void SetNextWindowFocus()
		{
			ImGuiNative.igSetNextWindowFocus();
		}

		public static void SetNextWindowPos(Vector2 pos)
		{
			ImGuiCond cond = ImGuiCond.None;
			ImGuiNative.igSetNextWindowPos(pos, cond, default(Vector2));
		}

		public static void SetNextWindowPos(Vector2 pos, ImGuiCond cond)
		{
			ImGuiNative.igSetNextWindowPos(pos, cond, default(Vector2));
		}

		public static void SetNextWindowPos(Vector2 pos, ImGuiCond cond, Vector2 pivot)
		{
			ImGuiNative.igSetNextWindowPos(pos, cond, pivot);
		}

		public static void SetNextWindowScroll(Vector2 scroll)
		{
			ImGuiNative.igSetNextWindowScroll(scroll);
		}

		public static void SetNextWindowSize(Vector2 size)
		{
			ImGuiCond cond = ImGuiCond.None;
			ImGuiNative.igSetNextWindowSize(size, cond);
		}

		public static void SetNextWindowSize(Vector2 size, ImGuiCond cond)
		{
			ImGuiNative.igSetNextWindowSize(size, cond);
		}

		public unsafe static void SetNextWindowSizeConstraints(Vector2 size_min, Vector2 size_max)
		{
			ImGuiSizeCallback custom_callback = null;
			void* custom_callback_data = null;
			ImGuiNative.igSetNextWindowSizeConstraints(size_min, size_max, custom_callback, custom_callback_data);
		}

		public unsafe static void SetNextWindowSizeConstraints(Vector2 size_min, Vector2 size_max, ImGuiSizeCallback custom_callback)
		{
			void* custom_callback_data = null;
			ImGuiNative.igSetNextWindowSizeConstraints(size_min, size_max, custom_callback, custom_callback_data);
		}

		public unsafe static void SetNextWindowSizeConstraints(Vector2 size_min, Vector2 size_max, ImGuiSizeCallback custom_callback, IntPtr custom_callback_data)
		{
			void* custom_callback_data2 = custom_callback_data.ToPointer();
			ImGuiNative.igSetNextWindowSizeConstraints(size_min, size_max, custom_callback, custom_callback_data2);
		}

		public static void SetNextWindowViewport(uint viewport_id)
		{
			ImGuiNative.igSetNextWindowViewport(viewport_id);
		}

		public static void SetScrollFromPosX(float local_x)
		{
			float center_x_ratio = 0.5f;
			ImGuiNative.igSetScrollFromPosX_Float(local_x, center_x_ratio);
		}

		public static void SetScrollFromPosX(float local_x, float center_x_ratio)
		{
			ImGuiNative.igSetScrollFromPosX_Float(local_x, center_x_ratio);
		}

		public static void SetScrollFromPosY(float local_y)
		{
			float center_y_ratio = 0.5f;
			ImGuiNative.igSetScrollFromPosY_Float(local_y, center_y_ratio);
		}

		public static void SetScrollFromPosY(float local_y, float center_y_ratio)
		{
			ImGuiNative.igSetScrollFromPosY_Float(local_y, center_y_ratio);
		}

		public static void SetScrollHereX()
		{
			ImGuiNative.igSetScrollHereX(0.5f);
		}

		public static void SetScrollHereX(float center_x_ratio)
		{
			ImGuiNative.igSetScrollHereX(center_x_ratio);
		}

		public static void SetScrollHereY()
		{
			ImGuiNative.igSetScrollHereY(0.5f);
		}

		public static void SetScrollHereY(float center_y_ratio)
		{
			ImGuiNative.igSetScrollHereY(center_y_ratio);
		}

		public static void SetScrollX(float scroll_x)
		{
			ImGuiNative.igSetScrollX_Float(scroll_x);
		}

		public static void SetScrollY(float scroll_y)
		{
			ImGuiNative.igSetScrollY_Float(scroll_y);
		}

		public unsafe static void SetStateStorage(ImGuiStoragePtr storage)
		{
			ImGuiNative.igSetStateStorage(storage.NativePtr);
		}

		public unsafe static void SetTabItemClosed(string tab_or_docked_window_label)
		{
			int num = 0;
			byte* ptr;
			if (tab_or_docked_window_label != null)
			{
				num = Encoding.UTF8.GetByteCount(tab_or_docked_window_label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(tab_or_docked_window_label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igSetTabItemClosed(ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void SetTooltip(string fmt)
		{
			int num = 0;
			byte* ptr;
			if (fmt != null)
			{
				num = Encoding.UTF8.GetByteCount(fmt);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(fmt, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igSetTooltip(ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public static void SetWindowCollapsed(bool collapsed)
		{
			int collapsed2 = (collapsed ? 1 : 0);
			ImGuiCond cond = ImGuiCond.None;
			ImGuiNative.igSetWindowCollapsed_Bool((byte)collapsed2, cond);
		}

		public static void SetWindowCollapsed(bool collapsed, ImGuiCond cond)
		{
			ImGuiNative.igSetWindowCollapsed_Bool((byte)(collapsed ? 1 : 0), cond);
		}

		public unsafe static void SetWindowCollapsed(string name, bool collapsed)
		{
			int num = 0;
			byte* ptr;
			if (name != null)
			{
				num = Encoding.UTF8.GetByteCount(name);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(name, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte collapsed2 = (byte)(collapsed ? 1 : 0);
			ImGuiCond cond = ImGuiCond.None;
			ImGuiNative.igSetWindowCollapsed_Str(ptr, collapsed2, cond);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void SetWindowCollapsed(string name, bool collapsed, ImGuiCond cond)
		{
			int num = 0;
			byte* ptr;
			if (name != null)
			{
				num = Encoding.UTF8.GetByteCount(name);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(name, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte collapsed2 = (byte)(collapsed ? 1 : 0);
			ImGuiNative.igSetWindowCollapsed_Str(ptr, collapsed2, cond);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public static void SetWindowFocus()
		{
			ImGuiNative.igSetWindowFocus_Nil();
		}

		public unsafe static void SetWindowFocus(string name)
		{
			int num = 0;
			byte* ptr;
			if (name != null)
			{
				num = Encoding.UTF8.GetByteCount(name);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(name, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igSetWindowFocus_Str(ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public static void SetWindowFontScale(float scale)
		{
			ImGuiNative.igSetWindowFontScale(scale);
		}

		public static void SetWindowPos(Vector2 pos)
		{
			ImGuiCond cond = ImGuiCond.None;
			ImGuiNative.igSetWindowPos_Vec2(pos, cond);
		}

		public static void SetWindowPos(Vector2 pos, ImGuiCond cond)
		{
			ImGuiNative.igSetWindowPos_Vec2(pos, cond);
		}

		public unsafe static void SetWindowPos(string name, Vector2 pos)
		{
			int num = 0;
			byte* ptr;
			if (name != null)
			{
				num = Encoding.UTF8.GetByteCount(name);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(name, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiCond cond = ImGuiCond.None;
			ImGuiNative.igSetWindowPos_Str(ptr, pos, cond);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void SetWindowPos(string name, Vector2 pos, ImGuiCond cond)
		{
			int num = 0;
			byte* ptr;
			if (name != null)
			{
				num = Encoding.UTF8.GetByteCount(name);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(name, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igSetWindowPos_Str(ptr, pos, cond);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public static void SetWindowSize(Vector2 size)
		{
			ImGuiCond cond = ImGuiCond.None;
			ImGuiNative.igSetWindowSize_Vec2(size, cond);
		}

		public static void SetWindowSize(Vector2 size, ImGuiCond cond)
		{
			ImGuiNative.igSetWindowSize_Vec2(size, cond);
		}

		public unsafe static void SetWindowSize(string name, Vector2 size)
		{
			int num = 0;
			byte* ptr;
			if (name != null)
			{
				num = Encoding.UTF8.GetByteCount(name);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(name, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiCond cond = ImGuiCond.None;
			ImGuiNative.igSetWindowSize_Str(ptr, size, cond);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void SetWindowSize(string name, Vector2 size, ImGuiCond cond)
		{
			int num = 0;
			byte* ptr;
			if (name != null)
			{
				num = Encoding.UTF8.GetByteCount(name);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(name, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igSetWindowSize_Str(ptr, size, cond);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void ShowAboutWindow()
		{
			byte* p_open = null;
			ImGuiNative.igShowAboutWindow(p_open);
		}

		public unsafe static void ShowAboutWindow(ref bool p_open)
		{
			byte b = (byte)(p_open ? 1 : 0);
			ImGuiNative.igShowAboutWindow(&b);
			p_open = b != 0;
		}

		public unsafe static void ShowDebugLogWindow()
		{
			byte* p_open = null;
			ImGuiNative.igShowDebugLogWindow(p_open);
		}

		public unsafe static void ShowDebugLogWindow(ref bool p_open)
		{
			byte b = (byte)(p_open ? 1 : 0);
			ImGuiNative.igShowDebugLogWindow(&b);
			p_open = b != 0;
		}

		public unsafe static void ShowDemoWindow()
		{
			byte* p_open = null;
			ImGuiNative.igShowDemoWindow(p_open);
		}

		public unsafe static void ShowDemoWindow(ref bool p_open)
		{
			byte b = (byte)(p_open ? 1 : 0);
			ImGuiNative.igShowDemoWindow(&b);
			p_open = b != 0;
		}

		public unsafe static void ShowFontSelector(string label)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igShowFontSelector(ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void ShowMetricsWindow()
		{
			byte* p_open = null;
			ImGuiNative.igShowMetricsWindow(p_open);
		}

		public unsafe static void ShowMetricsWindow(ref bool p_open)
		{
			byte b = (byte)(p_open ? 1 : 0);
			ImGuiNative.igShowMetricsWindow(&b);
			p_open = b != 0;
		}

		public unsafe static void ShowStackToolWindow()
		{
			byte* p_open = null;
			ImGuiNative.igShowStackToolWindow(p_open);
		}

		public unsafe static void ShowStackToolWindow(ref bool p_open)
		{
			byte b = (byte)(p_open ? 1 : 0);
			ImGuiNative.igShowStackToolWindow(&b);
			p_open = b != 0;
		}

		public unsafe static void ShowStyleEditor()
		{
			ImGuiStyle* ptr = null;
			ImGuiNative.igShowStyleEditor(ptr);
		}

		public unsafe static void ShowStyleEditor(ImGuiStylePtr @ref)
		{
			ImGuiNative.igShowStyleEditor(@ref.NativePtr);
		}

		public unsafe static bool ShowStyleSelector(string label)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igShowStyleSelector(ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public static void ShowUserGuide()
		{
			ImGuiNative.igShowUserGuide();
		}

		public unsafe static bool SliderAngle(string label, ref float v_rad)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_degrees_min = -360f;
			float v_degrees_max = 360f;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.0f deg");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.0f deg", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (float* v_rad2 = &v_rad)
			{
				byte num3 = ImGuiNative.igSliderAngle(ptr, v_rad2, v_degrees_min, v_degrees_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderAngle(string label, ref float v_rad, float v_degrees_min)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float v_degrees_max = 360f;
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.0f deg");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.0f deg", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (float* v_rad2 = &v_rad)
			{
				byte num3 = ImGuiNative.igSliderAngle(ptr, v_rad2, v_degrees_min, v_degrees_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderAngle(string label, ref float v_rad, float v_degrees_min, float v_degrees_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.0f deg");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.0f deg", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (float* v_rad2 = &v_rad)
			{
				byte num3 = ImGuiNative.igSliderAngle(ptr, v_rad2, v_degrees_min, v_degrees_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderAngle(string label, ref float v_rad, float v_degrees_min, float v_degrees_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (float* v_rad2 = &v_rad)
			{
				byte num3 = ImGuiNative.igSliderAngle(ptr, v_rad2, v_degrees_min, v_degrees_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderAngle(string label, ref float v_rad, float v_degrees_min, float v_degrees_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (float* v_rad2 = &v_rad)
			{
				byte num3 = ImGuiNative.igSliderAngle(ptr, v_rad2, v_degrees_min, v_degrees_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderFloat(string label, ref float v, float v_min, float v_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (float* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderFloat(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderFloat(string label, ref float v, float v_min, float v_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (float* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderFloat(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderFloat(string label, ref float v, float v_min, float v_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (float* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderFloat(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderFloat2(string label, ref Vector2 v, float v_min, float v_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector2* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderFloat2(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderFloat2(string label, ref Vector2 v, float v_min, float v_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector2* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderFloat2(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderFloat2(string label, ref Vector2 v, float v_min, float v_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (Vector2* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderFloat2(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderFloat3(string label, ref Vector3 v, float v_min, float v_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector3* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderFloat3(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderFloat3(string label, ref Vector3 v, float v_min, float v_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector3* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderFloat3(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderFloat3(string label, ref Vector3 v, float v_min, float v_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (Vector3* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderFloat3(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderFloat4(string label, ref Vector4 v, float v_min, float v_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector4* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderFloat4(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderFloat4(string label, ref Vector4 v, float v_min, float v_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (Vector4* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderFloat4(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderFloat4(string label, ref Vector4 v, float v_min, float v_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (Vector4* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderFloat4(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderInt(string label, ref int v, int v_min, int v_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderInt(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderInt(string label, ref int v, int v_min, int v_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderInt(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderInt(string label, ref int v, int v_min, int v_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderInt(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderInt2(string label, ref int v, int v_min, int v_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderInt2(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderInt2(string label, ref int v, int v_min, int v_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderInt2(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderInt2(string label, ref int v, int v_min, int v_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderInt2(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderInt3(string label, ref int v, int v_min, int v_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderInt3(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderInt3(string label, ref int v, int v_min, int v_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderInt3(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderInt3(string label, ref int v, int v_min, int v_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderInt3(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderInt4(string label, ref int v, int v_min, int v_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderInt4(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderInt4(string label, ref int v, int v_min, int v_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderInt4(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderInt4(string label, ref int v, int v_min, int v_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igSliderInt4(ptr, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool SliderScalar(string label, ImGuiDataType data_type, IntPtr p_data, IntPtr p_min, IntPtr p_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_min2 = p_min.ToPointer();
			void* p_max2 = p_max.ToPointer();
			byte* format = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			byte num2 = ImGuiNative.igSliderScalar(ptr, data_type, p_data2, p_min2, p_max2, format, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool SliderScalar(string label, ImGuiDataType data_type, IntPtr p_data, IntPtr p_min, IntPtr p_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_min2 = p_min.ToPointer();
			void* p_max2 = p_max.ToPointer();
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			byte num3 = ImGuiNative.igSliderScalar(ptr, data_type, p_data2, p_min2, p_max2, ptr2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public unsafe static bool SliderScalar(string label, ImGuiDataType data_type, IntPtr p_data, IntPtr p_min, IntPtr p_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_min2 = p_min.ToPointer();
			void* p_max2 = p_max.ToPointer();
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			byte num3 = ImGuiNative.igSliderScalar(ptr, data_type, p_data2, p_min2, p_max2, ptr2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public unsafe static bool SliderScalarN(string label, ImGuiDataType data_type, IntPtr p_data, int components, IntPtr p_min, IntPtr p_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_min2 = p_min.ToPointer();
			void* p_max2 = p_max.ToPointer();
			byte* format = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			byte num2 = ImGuiNative.igSliderScalarN(ptr, data_type, p_data2, components, p_min2, p_max2, format, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool SliderScalarN(string label, ImGuiDataType data_type, IntPtr p_data, int components, IntPtr p_min, IntPtr p_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_min2 = p_min.ToPointer();
			void* p_max2 = p_max.ToPointer();
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			byte num3 = ImGuiNative.igSliderScalarN(ptr, data_type, p_data2, components, p_min2, p_max2, ptr2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public unsafe static bool SliderScalarN(string label, ImGuiDataType data_type, IntPtr p_data, int components, IntPtr p_min, IntPtr p_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_min2 = p_min.ToPointer();
			void* p_max2 = p_max.ToPointer();
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			byte num3 = ImGuiNative.igSliderScalarN(ptr, data_type, p_data2, components, p_min2, p_max2, ptr2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public unsafe static bool SmallButton(string label)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igSmallButton(ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public static void Spacing()
		{
			ImGuiNative.igSpacing();
		}

		public unsafe static void StyleColorsClassic()
		{
			ImGuiStyle* dst = null;
			ImGuiNative.igStyleColorsClassic(dst);
		}

		public unsafe static void StyleColorsClassic(ImGuiStylePtr dst)
		{
			ImGuiNative.igStyleColorsClassic(dst.NativePtr);
		}

		public unsafe static void StyleColorsDark()
		{
			ImGuiStyle* dst = null;
			ImGuiNative.igStyleColorsDark(dst);
		}

		public unsafe static void StyleColorsDark(ImGuiStylePtr dst)
		{
			ImGuiNative.igStyleColorsDark(dst.NativePtr);
		}

		public unsafe static void StyleColorsLight()
		{
			ImGuiStyle* dst = null;
			ImGuiNative.igStyleColorsLight(dst);
		}

		public unsafe static void StyleColorsLight(ImGuiStylePtr dst)
		{
			ImGuiNative.igStyleColorsLight(dst.NativePtr);
		}

		public unsafe static bool TabItemButton(string label)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiTabItemFlags flags = ImGuiTabItemFlags.None;
			byte num2 = ImGuiNative.igTabItemButton(ptr, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool TabItemButton(string label, ImGuiTabItemFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igTabItemButton(ptr, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public static int TableGetColumnCount()
		{
			return ImGuiNative.igTableGetColumnCount();
		}

		public static ImGuiTableColumnFlags TableGetColumnFlags()
		{
			return ImGuiNative.igTableGetColumnFlags(-1);
		}

		public static ImGuiTableColumnFlags TableGetColumnFlags(int column_n)
		{
			return ImGuiNative.igTableGetColumnFlags(column_n);
		}

		public static int TableGetColumnIndex()
		{
			return ImGuiNative.igTableGetColumnIndex();
		}

		public unsafe static string TableGetColumnName()
		{
			return Util.StringFromPtr(ImGuiNative.igTableGetColumnName_Int(-1));
		}

		public unsafe static string TableGetColumnName(int column_n)
		{
			return Util.StringFromPtr(ImGuiNative.igTableGetColumnName_Int(column_n));
		}

		public static int TableGetRowIndex()
		{
			return ImGuiNative.igTableGetRowIndex();
		}

		public unsafe static ImGuiTableSortSpecsPtr TableGetSortSpecs()
		{
			return new ImGuiTableSortSpecsPtr(ImGuiNative.igTableGetSortSpecs());
		}

		public unsafe static void TableHeader(string label)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igTableHeader(ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public static void TableHeadersRow()
		{
			ImGuiNative.igTableHeadersRow();
		}

		public static bool TableNextColumn()
		{
			return ImGuiNative.igTableNextColumn() != 0;
		}

		public static void TableNextRow()
		{
			float min_row_height = 0f;
			ImGuiNative.igTableNextRow(ImGuiTableRowFlags.None, min_row_height);
		}

		public static void TableNextRow(ImGuiTableRowFlags row_flags)
		{
			float min_row_height = 0f;
			ImGuiNative.igTableNextRow(row_flags, min_row_height);
		}

		public static void TableNextRow(ImGuiTableRowFlags row_flags, float min_row_height)
		{
			ImGuiNative.igTableNextRow(row_flags, min_row_height);
		}

		public static void TableSetBgColor(ImGuiTableBgTarget target, uint color)
		{
			int column_n = -1;
			ImGuiNative.igTableSetBgColor(target, color, column_n);
		}

		public static void TableSetBgColor(ImGuiTableBgTarget target, uint color, int column_n)
		{
			ImGuiNative.igTableSetBgColor(target, color, column_n);
		}

		public static void TableSetColumnEnabled(int column_n, bool v)
		{
			byte v2 = (byte)(v ? 1 : 0);
			ImGuiNative.igTableSetColumnEnabled(column_n, v2);
		}

		public static bool TableSetColumnIndex(int column_n)
		{
			return ImGuiNative.igTableSetColumnIndex(column_n) != 0;
		}

		public unsafe static void TableSetupColumn(string label)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiTableColumnFlags flags = ImGuiTableColumnFlags.None;
			float init_width_or_weight = 0f;
			uint user_id = 0u;
			ImGuiNative.igTableSetupColumn(ptr, flags, init_width_or_weight, user_id);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void TableSetupColumn(string label, ImGuiTableColumnFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float init_width_or_weight = 0f;
			uint user_id = 0u;
			ImGuiNative.igTableSetupColumn(ptr, flags, init_width_or_weight, user_id);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void TableSetupColumn(string label, ImGuiTableColumnFlags flags, float init_width_or_weight)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			uint user_id = 0u;
			ImGuiNative.igTableSetupColumn(ptr, flags, init_width_or_weight, user_id);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void TableSetupColumn(string label, ImGuiTableColumnFlags flags, float init_width_or_weight, uint user_id)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igTableSetupColumn(ptr, flags, init_width_or_weight, user_id);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public static void TableSetupScrollFreeze(int cols, int rows)
		{
			ImGuiNative.igTableSetupScrollFreeze(cols, rows);
		}

		public unsafe static void Text(string fmt)
		{
			int num = 0;
			byte* ptr;
			if (fmt != null)
			{
				num = Encoding.UTF8.GetByteCount(fmt);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(fmt, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igText(ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void TextColored(Vector4 col, string fmt)
		{
			int num = 0;
			byte* ptr;
			if (fmt != null)
			{
				num = Encoding.UTF8.GetByteCount(fmt);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(fmt, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igTextColored(col, ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void TextDisabled(string fmt)
		{
			int num = 0;
			byte* ptr;
			if (fmt != null)
			{
				num = Encoding.UTF8.GetByteCount(fmt);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(fmt, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igTextDisabled(ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void TextUnformatted(string text)
		{
			int num = 0;
			byte* ptr;
			if (text != null)
			{
				num = Encoding.UTF8.GetByteCount(text);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(text, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte* text_end = null;
			ImGuiNative.igTextUnformatted(ptr, text_end);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void TextWrapped(string fmt)
		{
			int num = 0;
			byte* ptr;
			if (fmt != null)
			{
				num = Encoding.UTF8.GetByteCount(fmt);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(fmt, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igTextWrapped(ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static bool TreeNode(string label)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igTreeNode_Str(ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool TreeNode(string str_id, string fmt)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (fmt != null)
			{
				num2 = Encoding.UTF8.GetByteCount(fmt);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(fmt, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			byte num3 = ImGuiNative.igTreeNode_StrStr(ptr, ptr2);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public unsafe static bool TreeNode(IntPtr ptr_id, string fmt)
		{
			void* ptr_id2 = ptr_id.ToPointer();
			int num = 0;
			byte* ptr;
			if (fmt != null)
			{
				num = Encoding.UTF8.GetByteCount(fmt);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(fmt, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igTreeNode_Ptr(ptr_id2, ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool TreeNodeEx(string label)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiTreeNodeFlags flags = ImGuiTreeNodeFlags.None;
			byte num2 = ImGuiNative.igTreeNodeEx_Str(ptr, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool TreeNodeEx(string label, ImGuiTreeNodeFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igTreeNodeEx_Str(ptr, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool TreeNodeEx(string str_id, ImGuiTreeNodeFlags flags, string fmt)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (fmt != null)
			{
				num2 = Encoding.UTF8.GetByteCount(fmt);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(fmt, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			byte num3 = ImGuiNative.igTreeNodeEx_StrStr(ptr, flags, ptr2);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public unsafe static bool TreeNodeEx(IntPtr ptr_id, ImGuiTreeNodeFlags flags, string fmt)
		{
			void* ptr_id2 = ptr_id.ToPointer();
			int num = 0;
			byte* ptr;
			if (fmt != null)
			{
				num = Encoding.UTF8.GetByteCount(fmt);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(fmt, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.igTreeNodeEx_Ptr(ptr_id2, flags, ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public static void TreePop()
		{
			ImGuiNative.igTreePop();
		}

		public unsafe static void TreePush(string str_id)
		{
			int num = 0;
			byte* ptr;
			if (str_id != null)
			{
				num = Encoding.UTF8.GetByteCount(str_id);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str_id, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igTreePush_Str(ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void TreePush(IntPtr ptr_id)
		{
			ImGuiNative.igTreePush_Ptr(ptr_id.ToPointer());
		}

		public static void Unindent()
		{
			ImGuiNative.igUnindent(0f);
		}

		public static void Unindent(float indent_w)
		{
			ImGuiNative.igUnindent(indent_w);
		}

		public static void UpdatePlatformWindows()
		{
			ImGuiNative.igUpdatePlatformWindows();
		}

		public unsafe static void Value(string prefix, bool b)
		{
			int num = 0;
			byte* ptr;
			if (prefix != null)
			{
				num = Encoding.UTF8.GetByteCount(prefix);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(prefix, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte b2 = (byte)(b ? 1 : 0);
			ImGuiNative.igValue_Bool(ptr, b2);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void Value(string prefix, int v)
		{
			int num = 0;
			byte* ptr;
			if (prefix != null)
			{
				num = Encoding.UTF8.GetByteCount(prefix);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(prefix, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igValue_Int(ptr, v);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void Value(string prefix, uint v)
		{
			int num = 0;
			byte* ptr;
			if (prefix != null)
			{
				num = Encoding.UTF8.GetByteCount(prefix);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(prefix, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.igValue_Uint(ptr, v);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void Value(string prefix, float v)
		{
			int num = 0;
			byte* ptr;
			if (prefix != null)
			{
				num = Encoding.UTF8.GetByteCount(prefix);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(prefix, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte* float_format = null;
			ImGuiNative.igValue_Float(ptr, v, float_format);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe static void Value(string prefix, float v, string float_format)
		{
			int num = 0;
			byte* ptr;
			if (prefix != null)
			{
				num = Encoding.UTF8.GetByteCount(prefix);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(prefix, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (float_format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(float_format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(float_format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiNative.igValue_Float(ptr, v, ptr2);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
		}

		public unsafe static bool VSliderFloat(string label, Vector2 size, ref float v, float v_min, float v_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%.3f");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%.3f", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (float* v2 = &v)
			{
				byte num3 = ImGuiNative.igVSliderFloat(ptr, size, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool VSliderFloat(string label, Vector2 size, ref float v, float v_min, float v_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (float* v2 = &v)
			{
				byte num3 = ImGuiNative.igVSliderFloat(ptr, size, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool VSliderFloat(string label, Vector2 size, ref float v, float v_min, float v_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (float* v2 = &v)
			{
				byte num3 = ImGuiNative.igVSliderFloat(ptr, size, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool VSliderInt(string label, Vector2 size, ref int v, int v_min, int v_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			num2 = Encoding.UTF8.GetByteCount("%d");
			byte* ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
			int utf2 = Util.GetUtf8("%d", ptr2, num2);
			ptr2[utf2] = 0;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igVSliderInt(ptr, size, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool VSliderInt(string label, Vector2 size, ref int v, int v_min, int v_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igVSliderInt(ptr, size, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool VSliderInt(string label, Vector2 size, ref int v, int v_min, int v_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			fixed (int* v2 = &v)
			{
				byte num3 = ImGuiNative.igVSliderInt(ptr, size, v2, v_min, v_max, ptr2, flags);
				if (num > 2048)
				{
					Util.Free(ptr);
				}
				if (num2 > 2048)
				{
					Util.Free(ptr2);
				}
				return num3 != 0;
			}
		}

		public unsafe static bool VSliderScalar(string label, Vector2 size, ImGuiDataType data_type, IntPtr p_data, IntPtr p_min, IntPtr p_max)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_min2 = p_min.ToPointer();
			void* p_max2 = p_max.ToPointer();
			byte* format = null;
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			byte num2 = ImGuiNative.igVSliderScalar(ptr, size, data_type, p_data2, p_min2, p_max2, format, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe static bool VSliderScalar(string label, Vector2 size, ImGuiDataType data_type, IntPtr p_data, IntPtr p_min, IntPtr p_max, string format)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_min2 = p_min.ToPointer();
			void* p_max2 = p_max.ToPointer();
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			ImGuiSliderFlags flags = ImGuiSliderFlags.None;
			byte num3 = ImGuiNative.igVSliderScalar(ptr, size, data_type, p_data2, p_min2, p_max2, ptr2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public unsafe static bool VSliderScalar(string label, Vector2 size, ImGuiDataType data_type, IntPtr p_data, IntPtr p_min, IntPtr p_max, string format, ImGuiSliderFlags flags)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			void* p_data2 = p_data.ToPointer();
			void* p_min2 = p_min.ToPointer();
			void* p_max2 = p_max.ToPointer();
			int num2 = 0;
			byte* ptr2;
			if (format != null)
			{
				num2 = Encoding.UTF8.GetByteCount(format);
				ptr2 = ((num2 <= 2048) ? stackalloc byte[(int)(uint)(num2 + 1)] : Util.Allocate(num2 + 1));
				int utf2 = Util.GetUtf8(format, ptr2, num2);
				ptr2[utf2] = 0;
			}
			else
			{
				ptr2 = null;
			}
			byte num3 = ImGuiNative.igVSliderScalar(ptr, size, data_type, p_data2, p_min2, p_max2, ptr2, flags);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			if (num2 > 2048)
			{
				Util.Free(ptr2);
			}
			return num3 != 0;
		}

		public static bool InputText(string label, byte[] buf, uint buf_size)
		{
			return InputText(label, buf, buf_size, ImGuiInputTextFlags.None, null, IntPtr.Zero);
		}

		public static bool InputText(string label, byte[] buf, uint buf_size, ImGuiInputTextFlags flags)
		{
			return InputText(label, buf, buf_size, flags, null, IntPtr.Zero);
		}

		public static bool InputText(string label, byte[] buf, uint buf_size, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback)
		{
			return InputText(label, buf, buf_size, flags, callback, IntPtr.Zero);
		}

		public unsafe static bool InputText(string label, byte[] buf, uint buf_size, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback, IntPtr user_data)
		{
			int byteCount = Encoding.UTF8.GetByteCount(label);
			byte* ptr = ((byteCount <= 2048) ? stackalloc byte[(int)(uint)(byteCount + 1)] : Util.Allocate(byteCount + 1));
			Util.GetUtf8(label, ptr, byteCount);
			bool result;
			fixed (byte* buf2 = buf)
			{
				result = ImGuiNative.igInputText(ptr, buf2, buf_size, flags, callback, user_data.ToPointer()) != 0;
			}
			if (byteCount > 2048)
			{
				Util.Free(ptr);
			}
			return result;
		}

		public static bool InputText(string label, ref string input, uint maxLength)
		{
			return InputText(label, ref input, maxLength, ImGuiInputTextFlags.None, null, IntPtr.Zero);
		}

		public static bool InputText(string label, ref string input, uint maxLength, ImGuiInputTextFlags flags)
		{
			return InputText(label, ref input, maxLength, flags, null, IntPtr.Zero);
		}

		public static bool InputText(string label, ref string input, uint maxLength, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback)
		{
			return InputText(label, ref input, maxLength, flags, callback, IntPtr.Zero);
		}

		public unsafe static bool InputText(string label, ref string input, uint maxLength, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback, IntPtr user_data)
		{
			int byteCount = Encoding.UTF8.GetByteCount(label);
			byte* ptr = ((byteCount <= 2048) ? stackalloc byte[(int)(uint)(byteCount + 1)] : Util.Allocate(byteCount + 1));
			Util.GetUtf8(label, ptr, byteCount);
			int byteCount2 = Encoding.UTF8.GetByteCount(input);
			int num = Math.Max((int)(maxLength + 1), byteCount2 + 1);
			byte* ptr2;
			byte* ptr3;
			if (num > 2048)
			{
				ptr2 = Util.Allocate(num);
				ptr3 = Util.Allocate(num);
			}
			else
			{
				ptr2 = stackalloc byte[(int)(uint)num];
				ptr3 = stackalloc byte[(int)(uint)num];
			}
			Util.GetUtf8(input, ptr2, num);
			uint byteCount3 = (uint)(num - byteCount2);
			Unsafe.InitBlockUnaligned(ptr2 + byteCount2, 0, byteCount3);
			Unsafe.CopyBlock(ptr3, ptr2, (uint)num);
			byte b = ImGuiNative.igInputText(ptr, ptr2, (uint)num, flags, callback, user_data.ToPointer());
			if (!Util.AreStringsEqual(ptr3, num, ptr2))
			{
				input = Util.StringFromPtr(ptr2);
			}
			if (byteCount > 2048)
			{
				Util.Free(ptr);
			}
			if (num > 2048)
			{
				Util.Free(ptr2);
				Util.Free(ptr3);
			}
			return b != 0;
		}

		public static bool InputTextMultiline(string label, ref string input, uint maxLength, Vector2 size)
		{
			return InputTextMultiline(label, ref input, maxLength, size, ImGuiInputTextFlags.None, null, IntPtr.Zero);
		}

		public static bool InputTextMultiline(string label, ref string input, uint maxLength, Vector2 size, ImGuiInputTextFlags flags)
		{
			return InputTextMultiline(label, ref input, maxLength, size, flags, null, IntPtr.Zero);
		}

		public static bool InputTextMultiline(string label, ref string input, uint maxLength, Vector2 size, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback)
		{
			return InputTextMultiline(label, ref input, maxLength, size, flags, callback, IntPtr.Zero);
		}

		public unsafe static bool InputTextMultiline(string label, ref string input, uint maxLength, Vector2 size, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback, IntPtr user_data)
		{
			int byteCount = Encoding.UTF8.GetByteCount(label);
			byte* ptr = ((byteCount <= 2048) ? stackalloc byte[(int)(uint)(byteCount + 1)] : Util.Allocate(byteCount + 1));
			Util.GetUtf8(label, ptr, byteCount);
			int byteCount2 = Encoding.UTF8.GetByteCount(input);
			int num = Math.Max((int)(maxLength + 1), byteCount2 + 1);
			byte* ptr2;
			byte* ptr3;
			if (num > 2048)
			{
				ptr2 = Util.Allocate(num);
				ptr3 = Util.Allocate(num);
			}
			else
			{
				ptr2 = stackalloc byte[(int)(uint)num];
				ptr3 = stackalloc byte[(int)(uint)num];
			}
			Util.GetUtf8(input, ptr2, num);
			uint byteCount3 = (uint)(num - byteCount2);
			Unsafe.InitBlockUnaligned(ptr2 + byteCount2, 0, byteCount3);
			Unsafe.CopyBlock(ptr3, ptr2, (uint)num);
			byte b = ImGuiNative.igInputTextMultiline(ptr, ptr2, (uint)num, size, flags, callback, user_data.ToPointer());
			if (!Util.AreStringsEqual(ptr3, num, ptr2))
			{
				input = Util.StringFromPtr(ptr2);
			}
			if (byteCount > 2048)
			{
				Util.Free(ptr);
			}
			if (num > 2048)
			{
				Util.Free(ptr2);
				Util.Free(ptr3);
			}
			return b != 0;
		}

		public static bool InputTextWithHint(string label, string hint, ref string input, uint maxLength)
		{
			return InputTextWithHint(label, hint, ref input, maxLength, ImGuiInputTextFlags.None, null, IntPtr.Zero);
		}

		public static bool InputTextWithHint(string label, string hint, ref string input, uint maxLength, ImGuiInputTextFlags flags)
		{
			return InputTextWithHint(label, hint, ref input, maxLength, flags, null, IntPtr.Zero);
		}

		public static bool InputTextWithHint(string label, string hint, ref string input, uint maxLength, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback)
		{
			return InputTextWithHint(label, hint, ref input, maxLength, flags, callback, IntPtr.Zero);
		}

		public unsafe static bool InputTextWithHint(string label, string hint, ref string input, uint maxLength, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback, IntPtr user_data)
		{
			int byteCount = Encoding.UTF8.GetByteCount(label);
			byte* ptr = ((byteCount <= 2048) ? stackalloc byte[(int)(uint)(byteCount + 1)] : Util.Allocate(byteCount + 1));
			Util.GetUtf8(label, ptr, byteCount);
			int byteCount2 = Encoding.UTF8.GetByteCount(hint);
			byte* ptr2 = ((byteCount2 <= 2048) ? stackalloc byte[(int)(uint)(byteCount2 + 1)] : Util.Allocate(byteCount2 + 1));
			Util.GetUtf8(hint, ptr2, byteCount2);
			int byteCount3 = Encoding.UTF8.GetByteCount(input);
			int num = Math.Max((int)(maxLength + 1), byteCount3 + 1);
			byte* ptr3;
			byte* ptr4;
			if (num > 2048)
			{
				ptr3 = Util.Allocate(num);
				ptr4 = Util.Allocate(num);
			}
			else
			{
				ptr3 = stackalloc byte[(int)(uint)num];
				ptr4 = stackalloc byte[(int)(uint)num];
			}
			Util.GetUtf8(input, ptr3, num);
			uint byteCount4 = (uint)(num - byteCount3);
			Unsafe.InitBlockUnaligned(ptr3 + byteCount3, 0, byteCount4);
			Unsafe.CopyBlock(ptr4, ptr3, (uint)num);
			byte b = ImGuiNative.igInputTextWithHint(ptr, ptr2, ptr3, (uint)num, flags, callback, user_data.ToPointer());
			if (!Util.AreStringsEqual(ptr4, num, ptr3))
			{
				input = Util.StringFromPtr(ptr3);
			}
			if (byteCount > 2048)
			{
				Util.Free(ptr);
			}
			if (byteCount2 > 2048)
			{
				Util.Free(ptr2);
			}
			if (num > 2048)
			{
				Util.Free(ptr3);
				Util.Free(ptr4);
			}
			return b != 0;
		}

		public static Vector2 CalcTextSize(string text)
		{
			return CalcTextSizeImpl(text);
		}

		public static Vector2 CalcTextSize(string text, int start)
		{
			return CalcTextSizeImpl(text, start);
		}

		public static Vector2 CalcTextSize(string text, float wrapWidth)
		{
			return CalcTextSizeImpl(text, 0, null, hideTextAfterDoubleHash: false, wrapWidth);
		}

		public static Vector2 CalcTextSize(string text, bool hideTextAfterDoubleHash)
		{
			bool hideTextAfterDoubleHash2 = hideTextAfterDoubleHash;
			return CalcTextSizeImpl(text, 0, null, hideTextAfterDoubleHash2);
		}

		public static Vector2 CalcTextSize(string text, int start, int length)
		{
			return CalcTextSizeImpl(text, start, length);
		}

		public static Vector2 CalcTextSize(string text, int start, bool hideTextAfterDoubleHash)
		{
			bool hideTextAfterDoubleHash2 = hideTextAfterDoubleHash;
			return CalcTextSizeImpl(text, start, null, hideTextAfterDoubleHash2);
		}

		public static Vector2 CalcTextSize(string text, int start, float wrapWidth)
		{
			return CalcTextSizeImpl(text, start, null, hideTextAfterDoubleHash: false, wrapWidth);
		}

		public static Vector2 CalcTextSize(string text, bool hideTextAfterDoubleHash, float wrapWidth)
		{
			bool hideTextAfterDoubleHash2 = hideTextAfterDoubleHash;
			return CalcTextSizeImpl(text, 0, null, hideTextAfterDoubleHash2, wrapWidth);
		}

		public static Vector2 CalcTextSize(string text, int start, int length, bool hideTextAfterDoubleHash)
		{
			return CalcTextSizeImpl(text, start, length, hideTextAfterDoubleHash);
		}

		public static Vector2 CalcTextSize(string text, int start, int length, float wrapWidth)
		{
			return CalcTextSizeImpl(text, start, length, hideTextAfterDoubleHash: false, wrapWidth);
		}

		public static Vector2 CalcTextSize(string text, int start, int length, bool hideTextAfterDoubleHash, float wrapWidth)
		{
			return CalcTextSizeImpl(text, start, length, hideTextAfterDoubleHash, wrapWidth);
		}

		private unsafe static Vector2 CalcTextSizeImpl(string text, int start = 0, int? length = null, bool hideTextAfterDoubleHash = false, float wrapWidth = -1f)
		{
			byte* ptr = null;
			byte* text_end = null;
			int num = 0;
			if (text != null)
			{
				int length2 = (length.HasValue ? length.Value : text.Length);
				num = Util.CalcSizeInUtf8(text, start, length2);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(text, start, length2, ptr, num);
				ptr[utf] = 0;
				text_end = ptr + utf;
			}
			Vector2 result = default(Vector2);
			ImGuiNative.igCalcTextSize(&result, ptr, text_end, hideTextAfterDoubleHash ? ((byte)1) : ((byte)0), wrapWidth);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return result;
		}

		public static bool InputText(string label, IntPtr buf, uint buf_size)
		{
			return InputText(label, buf, buf_size, ImGuiInputTextFlags.None, null, IntPtr.Zero);
		}

		public static bool InputText(string label, IntPtr buf, uint buf_size, ImGuiInputTextFlags flags)
		{
			return InputText(label, buf, buf_size, flags, null, IntPtr.Zero);
		}

		public static bool InputText(string label, IntPtr buf, uint buf_size, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback)
		{
			return InputText(label, buf, buf_size, flags, callback, IntPtr.Zero);
		}

		public unsafe static bool InputText(string label, IntPtr buf, uint buf_size, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback, IntPtr user_data)
		{
			int byteCount = Encoding.UTF8.GetByteCount(label);
			byte* ptr = ((byteCount <= 2048) ? stackalloc byte[(int)(uint)(byteCount + 1)] : Util.Allocate(byteCount + 1));
			Util.GetUtf8(label, ptr, byteCount);
			bool result = ImGuiNative.igInputText(ptr, (byte*)buf.ToPointer(), buf_size, flags, callback, user_data.ToPointer()) != 0;
			if (byteCount > 2048)
			{
				Util.Free(ptr);
			}
			return result;
		}

		public unsafe static bool Begin(string name, ImGuiWindowFlags flags)
		{
			int byteCount = Encoding.UTF8.GetByteCount(name);
			byte* ptr = ((byteCount <= 2048) ? stackalloc byte[(int)(uint)(byteCount + 1)] : Util.Allocate(byteCount + 1));
			Util.GetUtf8(name, ptr, byteCount);
			byte* p_open = null;
			byte num = ImGuiNative.igBegin(ptr, p_open, flags);
			if (byteCount > 2048)
			{
				Util.Free(ptr);
			}
			return num != 0;
		}

		public static bool MenuItem(string label, bool enabled)
		{
			return MenuItem(label, string.Empty, selected: false, enabled);
		}
	}
}
