using CoolBook.Wpf.Core;
using CoolBook.Wpf.Model.Enums;

namespace CoolBook.Wpf.Model
{
    public class SpaceBook : BaseNotifyPropertyChanged
    {
        private const string _gap = "\n\t";
        private string pages;

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _messages;
        public string Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                OnPropertyChanged(nameof(Messages));
            }
        }

        public SpaceBookManager Manager { get; set; }

        public SpaceBook(string name)
        {
            Name = name;
            Messages = string.Empty;
            Manager = SpaceBookManager.GetInstance();

            if (!Manager.ContainsKey(Name))
                Manager.Add(Name, this);
            else
                Manager[Name] = this;
        }

        public void ReceivePoke(string friend, PokeType? type)
        {
            pages += _gap + friend + GetActionText(type);
            UpdateWall();
        }

        public void SendPoke(string who, PokeType? type, string friend)
        {
            Manager[friend].ReceivePoke(who, type);
        }

        public void SendPoke(PokeType? type, string friend)
        {
            SendPoke(Name, type, friend);
        }

        public void ReceiveGift(string friend, GiftType? type)
        {
            pages += _gap + friend + GetActionText(type);
            UpdateWall();
        }

        public void SendGift(string who, GiftType? type, string friend)
        {
            Manager[friend].ReceiveGift(who, type);
        }

        public void SendGift(GiftType? type, string friend)
        {
            SendGift(Name, type, friend);
        }

        private string GetActionText(PokeType? type)
        {
            var action = string.Empty;
            switch (type)
            {
                case PokeType.Poke:
                    action = " poked you";
                    break;
                case PokeType.Hug:
                    action = " hugged you";
                    break;
                default:
                    break;
            }

            return action;
        }

        private string GetActionText(GiftType? type)
        {
            var action = "";
            switch (type)
            {
                case GiftType.BonusPoints:
                    action = " gave you bonus points";
                    break;
                case GiftType.Flower:
                    action = " gave you a flower";
                    break;
                case GiftType.Heart:
                    action = " gave you a heart";
                    break;
                case GiftType.Jewelry:
                    action = " gave you a jewelry";
                    break;
                case GiftType.Star:
                    action = " gave you a star";
                    break;
                default:
                    break;
            }

            return action;
        }

        private void UpdateWall()
        {
            Messages = "======== " + Name + "'s SpaceBook =========\n" +
                pages +
                _gap + "\n===================================";
        }
    }
}