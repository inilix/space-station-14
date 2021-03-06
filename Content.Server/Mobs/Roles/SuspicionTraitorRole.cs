using Content.Server.GameObjects;
using Content.Server.Interfaces.Chat;
using Robust.Shared.IoC;
using Robust.Shared.Utility;
using Content.Shared.Antags;

namespace Content.Server.Mobs.Roles
{
    public sealed class SuspicionTraitorRole : Role
    {
        public AntagPrototype Prototype { get; }

        public SuspicionTraitorRole(Mind mind, AntagPrototype antagPrototype) : base(mind)
        {
            Prototype = antagPrototype;
            Name = antagPrototype.Name;
            Antagonist = antagPrototype.Antagonist;
        }

        public override string Name { get; }
        public string Objective => Prototype.Objective;
        public override bool Antagonist { get; }

        public override void Greet()
        {
            base.Greet();

            var chat = IoCManager.Resolve<IChatManager>();
            chat.DispatchServerMessage(Mind.Session, $"You're a {Name}!");
            chat.DispatchServerMessage(Mind.Session, $"Objective: {Objective}");
        }
    }
}
