﻿using System;
using Mapping_Tools.Classes.SnappingTools.DataStructure.RelevantObject;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Mapping_Tools.Classes.SnappingTools.DataStructure.RelevantObjectGenerators.GeneratorInputSelection {
    public class SelectionPredicateCollection : IEquatable<SelectionPredicateCollection> {
        public ObservableCollection<SelectionPredicate> Predicates { get; set; }

        public SelectionPredicateCollection() {
            Predicates = new ObservableCollection<SelectionPredicate>();
        }

        public bool Check(IRelevantObject relevantObject, RelevantObjectsGenerator generator) {
            return Predicates.Count == 0 || Predicates.Any(o => o.Check(relevantObject, generator));
        }

        public override string ToString() {
            StringBuilder builder = new StringBuilder();
            builder.Append('{');
            foreach (var selectionPredicate in Predicates) {
                builder.Append(selectionPredicate);
                builder.Append(", ");
            }

            builder.Remove(builder.Length - 2, 2);
            builder.Append('}');

            return builder.ToString();
        }

        public bool Equals(SelectionPredicateCollection other) {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (Predicates.Count != other.Predicates.Count) return false;
            return !Predicates.Where((t, i) => !t.Equals(other.Predicates[i])).Any();
        }

        public override bool Equals(object obj) {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((SelectionPredicateCollection) obj);
        }

        public override int GetHashCode() {
            return Predicates.GetHashCode();
        }
    }
}