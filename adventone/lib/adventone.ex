defmodule AdventOne do
  def main(args) do
    case args do
      [] -> IO.puts "Need a file."
      [cmd, file| _] when cmd == "sum" -> 
      process_file(file, &sum_list/1)
      [cmd, file| _] when cmd == "twice" -> 
      process_file(file, &find_repeat/1)
      [cmd, file| _] when cmd == "fasttwice" -> 
      process_file(file, &find_repeat_mapset/1)
    end
  end

  defp process_file(file, f) do
    case File.read(file) do
      {:ok, body} -> body
      |> String.split("\n", trim: true)
      |> f.()
      |> IO.inspect
      {:error, _} -> IO.puts "File not found: #{file}"
    end
  end

  def sum_list([]) do
    0
  end

  def sum_list([h|t]) do
    {val, ""} = Integer.parse(h)
    val + sum_list(t)
  end

  def find_repeat(lines) do
    find_repeat(lines, [0])
  end

  def find_repeat([h|t], history) do
    {val, ""} = Integer.parse(h)
    sum = val + hd(history)
    cond do
      sum in history -> sum
      true -> find_repeat(t ++ [h], [sum] ++ history)
    end
  end

  def find_repeat_mapset(lines) do
    find_repeat_mapset(lines, MapSet.new([0]), 0)
  end

  def find_repeat_mapset([h|t], set, sum) do
    {val, ""} = Integer.parse(h)
    newsum = val + sum
    if MapSet.member?(set, newsum) do
      newsum
    else
      find_repeat_mapset(t ++ [h], MapSet.put(set, newsum), newsum)
    end
  end
end
