using System;
using System.Collections.Generic;

namespace Fill {

    internal enum State {
        Old,
        New
    }

    internal readonly struct Point {
        internal readonly State state;
        internal readonly int color;
        internal Point(State state, int color) {
            this.state = state;
            this.color = color;
        }
    }

    public class Fill {
        public int[,] fill(int[,] input, int start_x, int start_y, int target_color, int replacement_color) {
            var work = copy_input_data(input, target_color);
            filler(work, start_x, start_y, target_color, replacement_color);
            var result = extract_result(work);
            return result;
        }

        private void filler(Point[,] data, int start_x, int start_y, int target_color, int replacement_color) {
            var queue = new Queue<ValueTuple<bool, int, int>>();
            if (!inside(data, start_x, start_y, target_color, replacement_color)) {
                return;
            }
        }

        private bool inside(Point[,] data, int x, int y, int target_color, int replacement_color) {
            var point = data[x, y];
            if (point.state == State.Old && point.color == target_color) {
                return true;
            } else {
                return false;
            }
        }

        private void set(Point[,] data, int x, int y, int target_color, int replacement_color) {
            var point = data[x, y];
            var new_point = new Point(State.New, point.color);
            data[x, y] = new_point;
        }

        private Point[,] copy_input_data(int[,] input, int target_color) {
            int height = input.GetLength(0);
            int width = input.GetLength(1);
            Point[,] work = new Point[height, width];
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    var point = new Point(State.Old, input[y, x]);
                    work[y, x] = point;
                }
            }
            return work;
        }

        private int[,] extract_result(Point[,] data) {
            int height = data.GetLength(0);
            int width = data.GetLength(1);
            int[,] work = new int[height, width];
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    var point = data[y, x];
                    work[y, x] = point.color;
                }
            }
            return work;
        }
    }
}