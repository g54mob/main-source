using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace UI
{
	public record TreeDialogParam(eWriterId writerId, TreeDialog.eTreeTab page, eLuggage selectLuggage = eLuggage.None)
	{
		[CompilerGenerated]
		protected virtual Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public eWriterId writerId { get; set; }

		public TreeDialog.eTreeTab page { get; set; }

		public eLuggage selectLuggage { get; set; }

		[CompilerGenerated]
		public override string ToString()
		{
			return null;
		}

		[CompilerGenerated]
		protected virtual bool PrintMembers(StringBuilder builder)
		{
			return false;
		}

		[CompilerGenerated]
		public virtual bool Equals(TreeDialogParam? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected TreeDialogParam(TreeDialogParam original)
		{
		}

		[CompilerGenerated]
		public void Deconstruct(out eWriterId writerId, out TreeDialog.eTreeTab page, out eLuggage selectLuggage)
		{
			writerId = default(eWriterId);
			page = default(TreeDialog.eTreeTab);
			selectLuggage = default(eLuggage);
		}
	}
}
