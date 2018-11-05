using System;
namespace HRApp.Models
{
    public sealed class ProgrammerRoles
    {
        public static readonly string JUNIOR = "JUNIOR";
        public static readonly string SENIOR = "SENIOR";
        public static readonly string LEADER = "LEADER";
        public static readonly string ARCHITECT = "ARCHITECT";
    }

    public abstract class IProgrammer
    {
        public int ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string ImagePath
        {
            get;
            set;
        }
        public string Role
        {
            get;
            set;
        }

        public abstract ProgrammerDecorator Promote( );
        public abstract ProgrammerDecorator Demote( );
    }

    public class Programmer : IProgrammer
    {
        public Programmer(int id, string Name, string ImPath)
        {
            this.ID = id;
            this.Name = Name;
            this.ImagePath = ImPath;
        }

        public override ProgrammerDecorator Demote()
        {
            throw new NotImplementedException();
        }

        public override ProgrammerDecorator Promote()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class ProgrammerDecorator : IProgrammer
    {
        protected IProgrammer Current_Programmer
        {
            get;
            set;
        }
        public ProgrammerDecorator(IProgrammer programmer)
        {
            this.Current_Programmer = programmer;
        }

        public void SetProgrammer(IProgrammer Programmer)
        {
            Current_Programmer = Programmer;
        }
        public IProgrammer GetProgramer()
        {
            return Current_Programmer;
        }

        public abstract string GetRole();
    }

    public class JuniorDev : ProgrammerDecorator
    {
        public JuniorDev(IProgrammer programmer) : base(programmer)
        {
            this.Current_Programmer.Role = ProgrammerRoles.JUNIOR;
            this.Role = ProgrammerRoles.JUNIOR;
            this.Current_Programmer.ImagePath = "images/dev.png";
            this.ImagePath = "images/dev.png";

        }


        public override ProgrammerDecorator Demote()
        {
            return this;
        }

        public override string GetRole()
        {
            return ProgrammerRoles.JUNIOR;
        }

        public override ProgrammerDecorator Promote()
        {
            return new SeniorDev(this.Current_Programmer);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class SeniorDev : ProgrammerDecorator
    {
        public SeniorDev(IProgrammer programmer) : base(programmer)
        {
            this.Current_Programmer.Role = ProgrammerRoles.SENIOR;
            this.Role = ProgrammerRoles.SENIOR;
            this.Current_Programmer.ImagePath = "images/senior.png";
            this.ImagePath = "images/senior.png";
        }

        public override ProgrammerDecorator Demote()
        {
            return new JuniorDev(this.Current_Programmer);
        }

        public override string GetRole()
        {
            return ProgrammerRoles.SENIOR;
        }

        public override ProgrammerDecorator Promote()
        {
            return new LeaderDev(this.Current_Programmer);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class LeaderDev : ProgrammerDecorator
    {
        public LeaderDev(IProgrammer programmer) : base(programmer)
        {
            this.Current_Programmer.Role = ProgrammerRoles.LEADER;
            this.Role = ProgrammerRoles.LEADER;
            this.Current_Programmer.ImagePath = "images/leader.png";
            this.ImagePath = "images/leader.png";
        }

        public override ProgrammerDecorator Demote()
        {
            return new SeniorDev(this.Current_Programmer);
        }

        public override string GetRole()
        {
            return ProgrammerRoles.LEADER;
        }

        public override ProgrammerDecorator Promote()
        {
            return new ArchitechtDev(this.Current_Programmer);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class ArchitechtDev : ProgrammerDecorator
    {
        public ArchitechtDev(IProgrammer programmer) : base(programmer)
        {
            this.Current_Programmer.Role = ProgrammerRoles.ARCHITECT;
            this.Role = ProgrammerRoles.ARCHITECT;
            this.Current_Programmer.ImagePath = "images/arch.png";
            this.ImagePath = "images/arch.png";
        }

        public override ProgrammerDecorator Demote()
        {
            return new LeaderDev(this.Current_Programmer);
        }

        public override string GetRole()
        {
            return ProgrammerRoles.ARCHITECT;
        }

        public override ProgrammerDecorator Promote()
        {
            return this;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }



}
