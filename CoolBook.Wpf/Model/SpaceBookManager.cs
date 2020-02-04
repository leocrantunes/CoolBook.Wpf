using CoolBook.Wpf.Core;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CoolBook.Wpf.Model
{
    public class SpaceBookManager : BaseNotifyPropertyChanged, IDictionary<string, SpaceBook>
    {
        private static SpaceBookManager _instance;
        private readonly SortedList<string, SpaceBook> _community;

        public ICollection<string> Keys => _community.Keys;

        public ICollection<SpaceBook> Values => _community.Values;

        public int Count => _community.Count;

        public bool IsReadOnly => false;

        public SpaceBook this[string key] { get => _community[key]; set => _community[key] = value; }

        private SpaceBookManager()
        {
            _community = new SortedList<string, SpaceBook>(100);
        }

        public static SpaceBookManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SpaceBookManager();
            }

            return _instance;
        }
        
        public void Add(string key, SpaceBook value)
        {
            _community.Add(key, value);
            OnPropertyChanged(nameof(Values));
        }

        public bool Remove(string key)
        {
            var result = _community.Remove(key);
            OnPropertyChanged(nameof(Values));

            return result;
        }

        public bool TryGetValue(string key, out SpaceBook value)
        {
            return _community.TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<string, SpaceBook> item)
        {
            _community.Add(item.Key, item.Value);
            OnPropertyChanged(nameof(Values));
        }

        public void Clear()
        {
            _community.Clear();
            OnPropertyChanged(nameof(Values));
        }

        public bool Contains(KeyValuePair<string, SpaceBook> item)
        {
            return _community.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, SpaceBook>[] array, int arrayIndex)
        {
            foreach (KeyValuePair<string, SpaceBook> kv in _community)
            {
                array[arrayIndex++] = new KeyValuePair<string, SpaceBook>(kv.Key, kv.Value);
            }
        }

        public bool Remove(KeyValuePair<string, SpaceBook> item)
        {
            var result = _community.Remove(item.Key);
            OnPropertyChanged(nameof(Values));

            return result;
        }

        public IEnumerator<KeyValuePair<string, SpaceBook>> GetEnumerator()
        {
            return _community.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _community.GetEnumerator();
        }

        public bool ContainsKey(string key)
        {
            return _community.ContainsKey(key);
        }
    }
}