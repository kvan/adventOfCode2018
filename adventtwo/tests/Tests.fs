module Tests

open System
open Xunit
open AdventTwo

[<Fact>]
let ``hasNumber finds something`` () =
    Assert.Equal(Some 'a', ProblemOne.hasNumber "aab" 2)
    Assert.Equal(Some 'b', ProblemOne.hasNumber "aabbb" 3)
    Assert.Equal(Some 'a', ProblemOne.hasNumber "aabb" 2)

[<Fact>]
let ``hasNumber finds nothing`` () =
    Assert.Equal(None, ProblemOne.hasNumber "abc" 2)

[<Fact>]
let ``checksum`` () =
    let boxes = [| "abcdef"; "bababc"; "abbcde"; "abcccd"; "aabcdd"; "abcdee"; "ababab" |]
    Assert.Equal(12, ProblemOne.checksum boxes)

[<Fact>]
let ``Hamming distance`` () =
    let foo = (ProblemTwo.hammingDistance "abc" "def")
    Assert.Equal(0, ProblemTwo.hammingDistance "abc" "abc")
    Assert.Equal(2, ProblemTwo.hammingDistance "abc" "cba")
    Assert.Equal(1, ProblemTwo.hammingDistance "abc" "abd")
    Assert.Equal(3, ProblemTwo.hammingDistance "abc" "bcd")
