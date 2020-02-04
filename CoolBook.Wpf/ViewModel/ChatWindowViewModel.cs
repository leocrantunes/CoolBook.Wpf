using CoolBook.Wpf.Core;
using CoolBook.Wpf.Model;
using CoolBook.Wpf.Model.Enums;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CoolBook.Wpf.ViewModel
{
    public class ChatWindowViewModel : BaseNotifyPropertyChanged
    {
        public ChatWindowViewModel(SpaceBook spaceBook)
        {
            this.SpaceBook = spaceBook;

            GiftTypes = new ObservableCollection<GiftType>(Enum.GetValues(typeof(GiftType)).Cast<GiftType>());
            PokeTypes = new ObservableCollection<PokeType>(Enum.GetValues(typeof(PokeType)).Cast<PokeType>());
        }
        
        private SpaceBook _myCoolBook;
        public SpaceBook SpaceBook
        {
            get { return _myCoolBook; }
            set
            {
                _myCoolBook = value;
                OnPropertyChanged(nameof(SpaceBook));
            }
        }

        private PokeType? _selectedPokeType;
        public PokeType? SelectedPokeType
        {
            get { return _selectedPokeType; }
            set
            {
                _selectedPokeType = value;
                OnPropertyChanged(nameof(SelectedPokeType));
            }
        }

        private GiftType? _selectedGiftType;
        public GiftType? SelectedGiftType
        {
            get { return _selectedGiftType; }
            set
            {
                _selectedGiftType = value;
                OnPropertyChanged(nameof(SelectedGiftType));
            }
        }

        public SpaceBook SelectedPokeTo { get; set; }

        public SpaceBook SelectedGiftTo { get; set; }

        public ObservableCollection<GiftType> GiftTypes { get; set; }

        public ObservableCollection<PokeType> PokeTypes { get; set; }

        public SpaceBookManager Manager { get; set; }

        public void SendGift()
        {
            SpaceBook.SendGift(SelectedGiftType, SelectedGiftTo.Name);
        }

        public void SendPoke()
        {
            SpaceBook.SendPoke(SelectedPokeType, SelectedPokeTo.Name);
        }
    }
}
