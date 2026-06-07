using System;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class ProgramInstruction : ProgramNode, IInstructionId, IGetInstructionById
	{
		[ProgramNodeProperty]
		private int _id = -1;

		public ProgramInstruction FirstChild { get; set; }

		int IInstructionId.Id
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
			}
		}

		public ProgramInstruction Next { get; set; }

		public virtual bool StopBreakPropagation => false;

		public virtual bool SupportsChildren => false;

		public virtual ProgramInstruction Execute(IThreadContext context)
		{
			return Next;
		}

		ProgramInstruction IGetInstructionById.GetInstructionById(int instructionId)
		{
			if (_id == instructionId)
			{
				return this;
			}
			if (Next != null)
			{
				ProgramInstruction instructionById = ((IGetInstructionById)Next).GetInstructionById(instructionId);
				if (instructionById != null)
				{
					return instructionById;
				}
			}
			if (FirstChild != null)
			{
				ProgramInstruction instructionById2 = ((IGetInstructionById)FirstChild).GetInstructionById(instructionId);
				if (instructionById2 != null)
				{
					return instructionById2;
				}
			}
			return null;
		}
	}
}
